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
        private Class.Structure oldOne;
        private Class.Game currentGame = null;
        private Spider.Class.Render.Renderer currentRenderer;

        private frmSettings instance = null;
        private string filePath = Path.Combine(Application.StartupPath, "Settings.xml");
        private Class.Save info = null;    

        public frmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.ReadSettings();

            if (this.info.HW_ACC)
                this.currentRenderer = new Spider.Class.Render.SlimDXRenderer();
            else
                this.currentRenderer = new Spider.Class.Render.GDIRenderer();

            this.currentRenderer.MouseDown += CurrentRenderer_MouseDown;
        }

        private void CurrentRenderer_MouseDown(MouseEventArgs e)
        {
            Class.Structure.Info strM = Class.Structure.FindByLocation(this.currentGame.MStructures, e.Location);
            if (strM.CurrentStructure != null)
            {
                if (Class.Structure.GetState(this.currentGame.MStructures))
                {
                    if (oldOne == strM.CurrentStructure)
                    {
                        Class.Structure.SetState(this.currentGame.MStructures, false);
                        this.Invalidate();
                        return;
                    }
                    Class.Structure oldStructure = Class.Structure.GetSelectedStructures(this.currentGame.MStructures)[0];
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
                    this.currentGame.CheckForWin();
                }
                else
                {
                    Class.Structure.SetState(this.currentGame.MStructures, false);
                    if (strM.SelectedCart == null)
                        return;
                    strM.SelectedCart.Selection = true;
                    oldOne = strM.CurrentStructure;

                    bool tryFinding = Class.Cart.CanMoveAllCards(this.currentGame.GetShouldSelectedCards(strM));
                    if (!tryFinding && this.currentGame.GetShouldSelectedCards(strM).Count == 0)
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

                    this.currentGame.CheckForWin();
                    this.Invalidate();

                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.currentRenderer.OnDestroy();
        }

        public void ReadSettings()
        {
            if (File.Exists(this.filePath))
            {
                Serialization.Serialization<Class.Save> s = new Serialization.Serialization<Class.Save>();
                this.info = s.Read(this.filePath, Serialization.Serialization<Class.Save>.Typ.Normal);
                try
                {
                    if (this.info.Background != string.Empty)
                        this.currentRenderer.BackgroundImage = Image.FromFile(this.info.Background);
                    else
                        this.currentRenderer.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "Image.jpg"));
                    this.currentRenderer.OnDraw();
                }
                catch 
                { }
            }
            else
                this.info = new Class.Save();
            Class.Structure.test = this.info;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            using (ModeDialog mld = new ModeDialog())
            {
                if (mld.ShowDialog(this) == DialogResult.OK)
                {
                    this.currentGame = new Class.Game(this, mld.SelectedMode);
                }
            }
            currentRenderer.OnInit(this.currentGame, this, this.info);
            this.currentGame.ReDraw += CurrentGame_ReDraw;
            this.currentGame.Refresh += CurrentGame_Refresh;

            this.mStrip.BackColor = Color.LightSkyBlue;
            this.mStrip.ForeColor = Color.Black;
        }

        private void CurrentGame_Refresh()
        {
            this.neueKartenToolStripMenuItem.Text = (this.currentGame.NewCards == 0 ? "Neue Karten (Sie haben keine Stapel mehr)" : String.Format("Neue Karten (Sie haben noch {0} Stapel)", this.currentGame.NewCards));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F2)
                this.currentGame.ContributeNewCars();
            else if (e.KeyCode == Keys.F3)
                this.showHelp();
            else if (e.Control && e.KeyCode == Keys.S)
                speicherStrgSToolStripMenuItem_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode == Keys.O)
                spielLadenToolStripMenuItem_Click(this, new EventArgs());
        }


        private void showHelp()
        {
            Class.Structure.ShowsAllTipps(this.currentGame.MStructures);
            this.currentRenderer.OnDraw();
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Sind Sie sich sicher, dass Sie das aktuelle Spiel abbrechen und ein neues Spiel starten möchten?", "Neues Spiel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Spider.Class.Game.Mode currentMode = Class.Game.Mode.OneSuit;

                using (ModeDialog mld = new ModeDialog())
                {
                    if (mld.ShowDialog(this) == DialogResult.OK)
                    {
                        currentMode = mld.SelectedMode;
                    }
                }
                this.currentGame.MStructures.Clear();
                this.currentGame.OtherCards.Clear();
                this.Controls.Remove(this.currentRenderer);
                this.currentGame = new Class.Game(this, currentMode);
                this.currentGame.Refresh += CurrentGame_Refresh;                
                this.currentGame.ReDraw += CurrentGame_ReDraw;
                this.currentRenderer.OnDraw();

                if (this.info.HW_ACC)
                    this.currentRenderer = new Spider.Class.Render.SlimDXRenderer();
                else
                    this.currentRenderer = new Spider.Class.Render.GDIRenderer();
                this.currentRenderer.MouseDown += CurrentRenderer_MouseDown;
                currentRenderer.OnInit(this.currentGame, this, this.info);
                currentRenderer.OnDraw();
            }
        }

        private void CurrentGame_ReDraw()
        {
            this.currentRenderer.OnDraw();
        }

        private void tippToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showHelp();
        }

        private void neueKartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentGame.ContributeNewCars();
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

        private void speicherStrgSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { AddExtension= true, DefaultExt = ".xml", Filter = ".xml|" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    this.currentGame.Save(sfd.FileName);
                }
            }                
        }

        private void spielLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = ".xml|" })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        Serialization.Serialization<Class.Game> gameSer = new Serialization.Serialization<Class.Game>();
                        this.currentGame.MStructures.Clear();
                        this.currentGame.OtherCards.Clear();
                        this.Controls.Remove(this.currentRenderer);
                        this.currentGame = gameSer.Read(ofd.FileName, Serialization.Serialization<Class.Game>.Typ.Normal);
                        this.currentGame.ReDraw += CurrentGame_ReDraw;
                        this.currentGame.Refresh += CurrentGame_Refresh;
                        this.Invalidate();

                        if (this.info.HW_ACC)
                            this.currentRenderer = new Spider.Class.Render.SlimDXRenderer();
                        else
                            this.currentRenderer = new Spider.Class.Render.GDIRenderer();
                        this.currentRenderer.MouseDown += CurrentRenderer_MouseDown;
                        currentRenderer.OnInit(this.currentGame, this, this.info);
                        currentRenderer.OnDraw();
                        this.currentRenderer.OnDraw();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Die Datei ist ungültig! Bitte wählen Sie eine gültige Datei aus!", "Gültige Datei auswählen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}