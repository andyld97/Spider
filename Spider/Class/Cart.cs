using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Spider.Class
{
    [Serializable]
    public class Cart
    {
        public cType ccType = cType.Default;
        public GameMode GameMode_ = GameMode.Black;
        public static Random rand = new Random();
        public bool Active;
        public bool Selection;
        public bool IsTipp;
        //public Structure owner;

        public Cart(cType ccType, GameMode gMode)
        {
            this.ccType = ccType;
            this.GameMode_ = gMode;
        }

        public Cart()
        { }

        public enum GameMode
        {
            Red,
            Black
        }

        public enum cType
        {
            Default, 
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven, 
            Eight, 
            Nine,
            Ten,
            J,
            Q,
            K
        }

        public static int CalculateDifference(cType one, cType two)
        {
            ExtendendList<cType> cTmp = new ExtendendList<cType>();
            foreach (string item in Enum.GetNames(typeof(cType)))
            {
                cType tmp = cType.Default;
                if (Enum.TryParse<cType>(item, out tmp))
                    cTmp.Add(tmp);
            }
            return Structure.Abs(cTmp.IndexOf(one) - cTmp.IndexOf(two));
        }

        public virtual Image ToImage()
        {
            try
            {
                return Image.FromFile(System.IO.Path.Combine(new string[] { Application.StartupPath, "Images", this.GameMode_.ToString(), this.ccType.ToString() + ".png" }));
                //return Image.FromFile(System.IO.Path.Combine(new string[] { Application.StartupPath, "Images", "Red", this.ccType.ToString() + ".png" }));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ExtendendList<Cart> CreateNewCarts(Game.Mode gameMode)
        {
            ExtendendList<Class.Cart> lstCarts = new ExtendendList<Class.Cart>();
            if (gameMode == Game.Mode.OneSuit)
            {
                for (int i = 0; i <= 7; i++)
                    for (int y = 1; y <= 13; y++)
                        lstCarts.Add(new Class.Cart((Class.Cart.cType)y, GameMode.Black));
            }
            else
            {
                for (int i = 0; i <= 7; i++)
                {
                    bool addFlag = false;
                    for (int y = 1; y <= 13; y++)
                    {
                        lstCarts.Add(new Class.Cart((Class.Cart.cType)y, (addFlag ? GameMode.Black : GameMode.Red)));
                        addFlag = !addFlag;
                    }
                }
            }
            // List is filled now.
            Cart.Shuffle<Cart>(lstCarts);
            return lstCarts;
        }

        public static ExtendendList<Cart> GetActiveCards(ExtendendList<Cart> lstCart)
        {
            ExtendendList<Cart> cd = new ExtendendList<Cart>();
            foreach (Cart tmp in lstCart)
                if (tmp.Active)
                    cd.Add(tmp);
            return cd;
        }

        public static void setState(ExtendendList<Cart> lstCarts, bool state)
        {
            foreach (Cart tmp in lstCarts)
                tmp.Active = state;
        }

        public static void setSelectedState(ExtendendList<Cart> lstCarts, bool state)
        {
            foreach (Cart tmp in lstCarts)
                tmp.Selection = state;
        }

        public static bool CanMoveAllCards(ExtendendList<Cart> lst)
        {
            ExtendendList<Cart> activeCards = Cart.GetActiveCards(lst);
            if (lst.Count == 1)
                return true;

            int diff = 0;
            for (int s = 0; s <= lst.Count - 1; s++)
            {
                if (s + 1 > lst.Count - 1)
                {
                    // Check if all cards are the same color, otherwise it isn't possible to move.
                    GameMode mdr = GameMode.Black;
                    for (int y = 0; y <= lst.Count - 1; y++)
                    {
                        if (y == 0)
                            mdr = lst[y].GameMode_;
                        else
                        {
                            if (mdr != lst[y].GameMode_)
                                return false;
                        }
                    }

                    return true;

                }
                diff = Cart.CalculateDifference(lst[s].ccType, lst[s + 1].ccType);
                if (Structure.Abs(diff) != 1)
                    return false;
            }

            return false;           
        }

        public static void Shuffle<T>(ExtendendList<T> ilist)
        {
            int iIndex;
            T tTmp;
            for (int i = 1; i < ilist.Count; ++i)
            {
                iIndex = rand.Next(i + 1);
                tTmp = ilist[i];
                ilist[i] = ilist[iIndex];
                ilist[iIndex] = tTmp;
            }
        }
    }
}