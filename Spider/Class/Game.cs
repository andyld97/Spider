using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;

namespace Spider.Class
{
    [Serializable]
    public class Game
    {
        public Class.ExtendendList<Cart> OtherCards = new ExtendendList<Cart>();
        public Class.ExtendendList<Class.Structure> MStructures;

        private int _newCards = 5;
        private bool endOfGame;

        public Mode GameMode;
        public SpecialCard[] WinningCards = new SpecialCard[8];
        public int WCounter = 0;

        public delegate void reDraw();
        public event reDraw ReDraw;

        public delegate void refresh();
        public event refresh Refresh;

        public enum Mode
        {
            OneSuit,
            TwoSuits,
            FourSuits,
        }

        public int NewCards
        {
            get { return this._newCards; }
            set
            {
                this._newCards = value;
                if (this.Refresh != null)
                    this.Refresh();
            }
        }

        public bool EndOfGame
        {
            get
            {
                return this.endOfGame;
            }
            set
            {
                this.endOfGame = value;
            }
        }

        public Game()
        {
            
        }

        public Game(frmMain owner, Mode GameMode)
        {            
            this.endOfGame = false;
            this.NewCards = 5;
            this.GameMode = GameMode;
            this.MStructures = Class.Structure.CreateStructureList(this);
        }

        private void throwEvent()
        {
            if (this.ReDraw != null)
                this.ReDraw();
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
            Class.Structure.Info infoR = Class.Structure.CheckWinning(this.MStructures);
            // ***************************************************************************************
            if (infoR.OK)
            {
                Class.ExtendendList<Class.Cart> toRemove = new Class.ExtendendList<Class.Cart>();
                for (int i = infoR.CurrentStructure.lstCards.IndexOf(infoR.SelectedCart); i <= infoR.CurrentStructure.lstCards.Count - 1; i++)
                    toRemove.Add(infoR.CurrentStructure.lstCards[i]);

                // 0 ... 1 it doesn't matter 
                Cart.GameMode currentMode = toRemove[0].GameMode_;

                foreach (Class.Cart toRem in toRemove)
                    infoR.CurrentStructure.lstCards.Remove(toRem);
                this.ReDraw();

                // Add a structure wird currentMode to the array.
                this.WinningCards[WCounter++] = new SpecialCard(currentMode);
                this.ReDraw();

                foreach (Class.Structure s in this.MStructures)
                {
                    if (s.lstCards.Count != 0)
                        if (!(s.lstCards[s.lstCards.Count - 1].Active))
                            s.lstCards[s.lstCards.Count - 1].Active = true;
                }
            }
            bool gameend = false;
            foreach (Class.Structure current in this.MStructures)
            {
                gameend = (current.lstCards.Count == 0);
                if (!gameend)
                    break;
            }
            this.endOfGame = gameend;
            this.throwEvent();
            // ---------------------------------------------------------------------------------------
        }

        public void ContributeNewCars()
        {
            bool succcess = Class.Structure.DistributeNewCars(this.MStructures, this);
            if (!succcess)
            {
                if (this.OtherCards.Count != 0)
                    MessageBox.Show("Bitte erst die Karten auf die leeren Felder verteilen!", "Leere Felder sind unzulässig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                this.NewCards--;

            if (this.NewCards < 0)
            {
                MessageBox.Show("Sie haben keine Stapel mehr!", "Keine Stapel mehr vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.NewCards = 0;
                this.ReDraw();
            }
            this.ReDraw();
        }

        public void Save(string path)
        {
            Serialization.Serialization<Game> gameSer = new Serialization.Serialization<Game>();
            gameSer.Save(path, this, Serialization.Serialization<Game>.Typ.Normal);
        }

    }
}
