using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Spider
{
    public partial class frmMain : Form
    {
        private Class.ExtendendList<Class.Structure> mStructures;
        private Class.Structure oldOne;
        private int _newCards = 5;
        private bool endOfGame;
        private frmSettings instance = null;
        private string filePath = Path.Combine(Application.StartupPath, "Settings.xml");
        private Class.Save test = null;

        public int newCards
        {
            get { return _newCards; }
            set
            {
                _newCards = value;
                this.neueKartenToolStripMenuItem.Text = (value == 0 ? "Neue Karten (Sie haben keine Stapel mehr)" : String.Format("Neue Karten (Sie haben noch {0} Stapel)", value));
            }
        }

        public frmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.ReadSettings();
        }

        public void ReadSettings()
        {
            if (File.Exists(this.filePath))
            {
                Serialization.Serialization<Class.Save> s = new Serialization.Serialization<Class.Save>();
                this.test = s.Read(this.filePath, Serialization.Serialization<Class.Save>.Typ.Normal);
                try
                {
                    if (this.test.Background != string.Empty)
                        this.BackgroundImage = Image.FromFile(this.test.Background);
                    else
                        this.BackgroundImage = Properties.Resources.Wood;
                    this.Invalidate();
                }
                catch 
                { }
            }
            else
                this.test = new Class.Save();
            Class.Structure.test = this.test;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mStructures = Class.Structure.CreateStructureList();
            this.Invalidate();

            this.mStrip.BackColor = Color.FromArgb(200, 230, 100, 70);
            this.mStrip.ForeColor = Color.Black;
            this.newCards = 5;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F2)
                this.contributeNewCars();
            else if (e.KeyCode == Keys.F3)
                this.showHelp();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Class.Structure.Info strM = Class.Structure.FindByLocation(this.mStructures, e.Location);
            if (strM.CurrentStructure != null)
            {
                if (Class.Structure.GetState(this.mStructures))
                {
                    if (oldOne == strM.CurrentStructure)
                    {
                        Class.Structure.SetState(this.mStructures, false);
                        this.Invalidate();
                        return;
                    }
                    Class.Structure oldStructure = Class.Structure.GetSelectedStructures(this.mStructures)[0];
                    // --------------------------------------------------------------------------------------
                    Class.ExtendendList<Class.Cart> items = new Class.ExtendendList<Class.Cart>();
                    foreach (Class.Cart cC in oldStructure.lstCards)
                        if (cC.Active && cC.Selection)
                            items.Add(cC);

                    bool canMoveStructureWithMoreThanThreeCards = Class.Structure.CanMoveCards(items);
                    bool canGoOn = false;

                    if (strM.CurrentStructure.lstCards.Count == 0)
                        canGoOn = canMoveStructureWithMoreThanThreeCards;
                    else if (items.Count < 2)
                    {
                        Class.Cart fCardOldOne = items[0];
                        Class.Cart fCardNewOne = strM.CurrentStructure.lstCards[strM.CurrentStructure.lstCards.Count - 1];
                        // Calculate the difference now! 
                        int diff = Class.Cart.CalculateDifference(fCardOldOne.ccType, fCardNewOne.ccType);
                        canGoOn = (diff == 1);
                    }
                    else
                    {
                        if (canMoveStructureWithMoreThanThreeCards)
                        {
                            // Proove: First card of the new structure have to be a difference from 1 to the first card in the structrue(oldone)
                            Class.Cart fCardOldOne = items[0];
                            Class.Cart fCardNewOne = strM.CurrentStructure.lstCards[strM.CurrentStructure.lstCards.Count - 1];
                            // Calculate the difference now! 
                            int diff = Class.Cart.CalculateDifference(fCardOldOne.ccType, fCardNewOne.ccType);
                            canGoOn = (diff == 1);
                        }
                    }
                    if (!canGoOn)
                    {
                        System.Console.Beep();
                        foreach (Class.Cart c in items)
                            c.Selection = false;
                        this.Invalidate();
                        return;
                    }
                    oldOne = null;  
                    Class.ExtendendList<Class.Cart> tmp = new Class.ExtendendList<Class.Cart>();
                    foreach (Class.Cart cC in oldStructure.lstCards)
                    {
                        if (cC.Active && cC.Selection)
                        {
                            tmp.Add(cC);
                            strM.CurrentStructure.lstCards.Add(cC);
                        }
                    }
                    Class.Structure.SetState(oldStructure, false);
                    Class.Structure.SetLastCartActiveIfPossible(oldStructure);
                    foreach (Class.Cart curCart in tmp)
                        oldStructure.lstCards.Remove(curCart);
                    if (oldStructure.lstCards.Count != 0)
                        oldStructure.lstCards[oldStructure.lstCards.Count - 1].Active = true;
                    this.Invalidate();
                    CheckForWin();
                }
                else
                {
                    Class.Structure.SetState(this.mStructures, false);
                    if (strM.SelectedCart == null)
                        return;
                    strM.SelectedCart.Selection = true;
                    oldOne = strM.CurrentStructure;

                    bool tryFinding = Class.Cart.CanMoveAllCards(this.GetShouldSelectedCards(strM));
                    if (!tryFinding && this.GetShouldSelectedCards(strM).Count == 0)
                    {
                        Class.ExtendendList<Class.Cart> lstCards = new Class.ExtendendList<Class.Cart>();
                        lstCards.Add(strM.SelectedCart);
                        tryFinding = Class.Cart.CanMoveAllCards(lstCards);
                    }

                    if (tryFinding)
                    {
                        Class.ExtendendList<Class.Cart> shouldSelected = new Class.ExtendendList<Class.Cart>();
                        // Select carts, which are under this cart
                        int index = strM.CurrentStructure.lstCards.IndexOf(strM.SelectedCart);
                        if (index != -1)
                        {
                            for (int i = index + 1; i <= strM.CurrentStructure.lstCards.Count - 1; i++)
                            {
                                Class.Cart current = strM.CurrentStructure.lstCards[i];
                                current.Selection = true;
                            }
                        }
                    }
                    else
                    {
                        strM.SelectedCart.Selection = false;
                        Console.Beep();
                    }

                    CheckForWin();
                    this.Invalidate();
          
                }
            }           
        }


        public Class.ExtendendList<Class.Cart> GetShouldSelectedCards(Class.Structure.Info strM)
        {
            Class.ExtendendList<Class.Cart> shouldSelected = new Class.ExtendendList<Class.Cart>();
            // Select carts, which are under this cart
            int index = strM.CurrentStructure.lstCards.IndexOf(strM.SelectedCart);
            if (index != -1)
            {
                for (int i = index; i <= strM.CurrentStructure.lstCards.Count - 1; i++)
                {
                    Class.Cart current = strM.CurrentStructure.lstCards[i];
                    shouldSelected.Add(current);
                }
            }
            return shouldSelected;
        }
  
        public void CheckForWin()
        {
            // Check for Winning here
            // ***************************************************************************************
            Class.Structure.Info infoR = Class.Structure.CheckWinning(this.mStructures);
            // ***************************************************************************************
            if (infoR.OK)
            {
                Class.ExtendendList<Class.Cart> toRemove = new Class.ExtendendList<Class.Cart>();
                for (int i = infoR.CurrentStructure.lstCards.IndexOf(infoR.SelectedCart); i <= infoR.CurrentStructure.lstCards.Count - 1; i++)
                    toRemove.Add(infoR.CurrentStructure.lstCards[i]);
                foreach (Class.Cart toRem in toRemove)
                    infoR.CurrentStructure.lstCards.Remove(toRem);
                this.Invalidate();

                foreach (Class.Structure s in this.mStructures)
                {
                    if (s.lstCards.Count != 0)
                        if (!(s.lstCards[s.lstCards.Count - 1].Active))
                            s.lstCards[s.lstCards.Count - 1].Active = true;
                }
            }
            bool gameend = false;
            foreach (Class.Structure current in this.mStructures)
            {
                gameend = (current.lstCards.Count == 0);
                if (!gameend)
                    break;
            }
            this.endOfGame = gameend;
            this.Invalidate();
            // ---------------------------------------------------------------------------------------
        }

        private void contributeNewCars()
        {
            bool succcess = Class.Structure.DistributeNewCars(this.mStructures);
            if (!succcess)
            {
                if (Class.Structure.OtherCards.Count != 0)
                    MessageBox.Show(this, "Bitte erst die Karten auf die leeren Felder verteilen!", "Leere Felder sind unzulässig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                newCards--;

            if (newCards < 0)
            {
                MessageBox.Show(this, "Sie haben keine Stapel mehr!", "Keine Stapel mehr vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                newCards = 0;
                this.Invalidate();
            }
            this.Invalidate();
        }

        private void showHelp()
        {
            Class.Structure.ShowsAllTipps(this.mStructures);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
           // e.Graphics.FillRectangle(new SolidBrush(Color.Green), this.DisplayRectangle);
            StringFormat alginment = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
            int i = 0, c = 0;
            foreach (Class.Structure mStr in this.mStructures)
            {
                c = 0;
                int cCard = 0;

                if (mStr.lstCards.Count == 0)
                {
                    // Empty field
                    e.Graphics.DrawRectangle(new Pen(Color.Violet), new Rectangle(i * (test.Distance + test.Width), test.Y + 10, 100, 150));
                    i++; // Because \/ there will be continued!!!!
                    continue;
                }

                foreach (Class.Cart mCart in mStr.lstCards)
                {
                    int x = i * (test.Width + test.Distance);
                    int y = test.Y + 10 + (c * 10);
                    if (!mCart.Active)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(x, y, test.Width, 5));
                    else
                    {
                        Rectangle actCard;
                        if (mStr.lstCards.IndexOf(mCart) == mStr.lstCards.Count - 1)
                            actCard = new Rectangle(i * (test.Width + test.Distance), y + (cCard * test.Distance2), test.Width, test.Height);
                        else
                            actCard = new Rectangle(i * (test.Width + test.Distance), y + (cCard * test.Distance2), test.Width, test.Distance2 * 2);

                        e.Graphics.DrawImageUnscaledAndClipped(mCart.ToImage(), actCard);

                        if (mCart.Selection)
                            e.Graphics.DrawRectangle(new Pen(Color.Green, 3), actCard);
                        int fact = 3;
                        if (mCart.IsTipp)
                            e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), new Rectangle(actCard.X + fact, actCard.Y + fact, actCard.Width - fact * 2, actCard.Height - fact * 2));
                        cCard++;
                    }
                    c++;
                }
                i++;
            }
            if (this.endOfGame)
                e.Graphics.DrawString("Sie haben gewonnen!", new Font("Segoe UI", 36, FontStyle.Regular), new SolidBrush(Color.White), this.DisplayRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Sind Sie sich sicher, dass Sie das aktuelle Spiel abbrechen und ein neues Spiel starten möchten?", "Neues Spiel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                mStructures = Class.Structure.CreateStructureList();
                this.endOfGame = false;
                this.newCards = 5;
                this.Invalidate();
            }
        }

        private void tippToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showHelp();
        }

        private void neueKartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.contributeNewCars();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new frmSettings(this);
                instance.Show();
            }
            else
                instance.BringToFront();
        }
    }
}