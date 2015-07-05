using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Spider.Class
{
    public class Cart
    {
        public cType ccType = cType.Default;
        public static Random rand = new Random();
        public bool Active;
        public bool Selection;
        public bool IsTipp;
        public Structure owner;

        public Cart(cType ccType)
        {
            this.ccType = ccType;
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

        public static string Convert(cType current)
        {
            switch (current)
            {
                case cType.Default: return "-1"; break;
                case cType.One: return "1"; break;
                case cType.Two: return "2"; break;
                case cType.Three: return "3"; break;
                case cType.Four: return "4"; break;
                case cType.Five: return "5"; break;
                case cType.Six: return "6"; break;
                case cType.Seven: return "7"; break;
                case cType.Eight: return "8"; break;
                case cType.Nine: return "9"; break;
                case cType.Ten: return "10"; break;
            }
            return current.ToString();
        }

        public static ExtendendList<Cart> CreateNewCarts()
        {
            ExtendendList<Class.Cart> lstCarts = new ExtendendList<Class.Cart>();
            for (int i = 0; i <= 7; i++)
                for (int y = 1; y <= 13; y++)
                    lstCarts.Add(new Class.Cart((Class.Cart.cType)y));
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