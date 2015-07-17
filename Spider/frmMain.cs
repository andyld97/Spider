using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spider
{
    public partial class frmMain : Form
    {
        private Class.ExtendendList<Class.Structure> mStructures;
        private Class.Structure oldOne;
        private int _newCards = 5;
        private bool endOfGame;

        public int newCards
        {
            get { return _newCards; }
            set
            {
                _newCards = value;
                this.lblCards.Text = (value == 0 ? "Sie haben keine Stapel mehr" : String.Format("Sie haben noch {0} Stapel", value));
            }
        }

        public frmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mStructures = Class.Structure.CreateStructureList();
            this.Width = 1500;
            this.Invalidate();
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
                        MessageBox.Show("Das funktioniert nicht!");
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
                    CheckForWin();
                    this.Invalidate();
          
                }
            }           
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), this.DisplayRectangle);
            StringFormat alginment = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
            int i = 0, c = 0;
            foreach (Class.Structure mStr in this.mStructures)
            {
                c = 0;
                int cCard = 0;

                if (mStr.lstCards.Count == 0)
                {
                    // Empty field
                    e.Graphics.DrawRectangle(new Pen(Color.Violet), new Rectangle(i * 150, 10, 100, 150));
                    i++; // Because \/ there will be continued!!!!
                    continue;
                }

                foreach (Class.Cart mCart in mStr.lstCards)
                {
                    int x = i * 150;
                    int y = 10 + (c * 10);
                    if (!mCart.Active)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(x, y, 100, 5));
                    else
                    {
                          Rectangle actCard;
                          Font toDraw;
                          if (mStr.lstCards.IndexOf(mCart) == mStr.lstCards.Count - 1)
                          {   
                              actCard = new Rectangle(i * 150, y + cCard * 50, 100, 150);
                              int sZ = (mCart.ccType == Class.Cart.cType.Ten) ? 50 : 72;
                              toDraw = new Font("Segoe UI", sZ, FontStyle.Regular);
                          }
                          else
                          {                     
                              actCard = new Rectangle(i * 150,  y + (cCard * 50), 100, 50);
                              toDraw = new Font("Segoe UI", 20, FontStyle.Regular);
                          }
                        e.Graphics.FillRectangle(new SolidBrush(Color.Blue), actCard);
                        e.Graphics.DrawString(Class.Cart.Convert(mCart.ccType), toDraw, new SolidBrush(Color.Black), actCard, alginment);
                        if (mCart.Selection)
                            e.Graphics.DrawRectangle(new Pen(Color.Yellow), actCard);
                        int fact = 3;
                        if (mCart.IsTipp)
                            e.Graphics.DrawRectangle(new Pen(Color.Bisque, 1), new Rectangle( actCard.X + fact, actCard.Y + fact, actCard.Width - fact*2, actCard.Height - fact*2));
                        cCard++;
                    }
                    c++;
                }
                i++;
            }
            if (this.endOfGame)
                e.Graphics.DrawString("Sie haben gewonnen!", new Font("Segoe UI", 36, FontStyle.Regular), new SolidBrush(Color.White), this.DisplayRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool succcess = Class.Structure.DistributeNewCars(this.mStructures);
            if (!succcess)
            {
                if (Class.Structure.OtherCards.Count != 0)
                    MessageBox.Show("Bitte erst die Karten auf die leeren Felder verteilen!");
            }
            else
                newCards--;

            if (newCards < 0)
                newCards = 0;

            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class.Structure.ShowsAllTipps(this.mStructures);
            this.Invalidate();
        }
    }
}