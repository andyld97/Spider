using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Spider.Class
{
    public class Structure
    {
        public SType Type = SType.Default;
        public ExtendendList<Cart> lstCards;
        public static ExtendendList<Cart> OtherCards = new ExtendendList<Cart>();

        public enum SType
        {
            Six,
            Five,
            Default
        }

        public Structure(ExtendendList<Cart> lstCards, SType Type)
        {
            this.lstCards = lstCards;
            this.Type = Type;
        }

        public static bool GetState(ExtendendList<Structure> lst)
        {
            foreach (Structure tmp in lst)
                foreach (Cart tmpC in tmp.lstCards)
                    if (tmpC.Selection)
                       return true;
            return false;
        }

        public static bool SetLastCartActiveIfPossible(Structure lst)
        {
            if (lst.lstCards.Count == 0)
                return false;

            lst.lstCards[lst.lstCards.Count - 1].Active = true;
            return true;
        }

        public static ExtendendList<Structure> GetSelectedStructures(ExtendendList<Structure> lst)
        {
            ExtendendList<Structure> tmpLst = new ExtendendList<Structure>();
            foreach (Structure tmp in lst)
                foreach (Cart tmpC in tmp.lstCards)
                    if (tmpC.Selection)
                        tmpLst.Add(tmp);
            return tmpLst;
        }

        public static void SetState(ExtendendList<Structure> lst, bool state)
        {
            lst.ForEach(delegate(Structure tmp)
            {
                foreach (Cart c in tmp.lstCards)
                {
                    c.Selection = state;
                    c.IsTipp = state;
                }
            });
        }

        public static void SetState(Structure lst, bool state)
        {
                foreach (Cart c in lst.lstCards)
                    c.Selection = state;
        }

        public static Info FindByLocation(ExtendendList<Structure> lst, Point p)
        {
            int i = 0, c = 0;
            Info toReturn = new Info();
            foreach (Class.Structure mStr in lst)
            {
                c = 0;
                int cCard = 0;
                int y2 = 0;
                Rectangle actCard;
                if (mStr.lstCards.Count == 0)
                {
                    if (new Rectangle(i * 150, 10, 100, 150).Contains(p))
                    {
                        toReturn.SelectedCart = null;
                        toReturn.CurrentStructure = mStr;
                        return toReturn;
                    }
                    i++;
                    continue;
                }

                foreach (Class.Cart mCart in mStr.lstCards)
                {
                    int x = i * 150;
                    int y = 10 + (c * 10);
                    if (!mCart.Active)
                        actCard = new Rectangle(x, y, 100, 5);
                    else
                    {
                        if (mStr.lstCards.IndexOf(mCart) == mStr.lstCards.Count - 1)
                            actCard = new Rectangle(i * 150, y + cCard * 50, 100, 150);
                        else
                            actCard = new Rectangle(i * 150, y + (cCard * 50), 100, 50);
                        cCard++;
                    }
                    c++;
                    if (actCard.Contains(p))
                    {
                        toReturn.SelectedCart = mCart;
                        toReturn.CurrentStructure = mStr;
                        return toReturn;
                    }
                }                
                i++;
            }
            return toReturn;
        }

        public struct Info
        {
            public Structure CurrentStructure;
            public Cart SelectedCart;
            public bool OK;

            public Info(Structure CurrentStructure, Cart SelectedCart, bool OK)
            {
                this.CurrentStructure = CurrentStructure;
                this.SelectedCart = SelectedCart;
                this.OK = OK;
            }
        }

        public static ExtendendList<Cart> FindActiveCars(ExtendendList<Cart> lst)
        {
            ExtendendList<Cart> tmp = new ExtendendList<Cart>();
            foreach (Cart ctr in lst)
                if (ctr.Active)
                    tmp.Add(ctr);
            return tmp;
        }

        public static bool CanMoveCards(ExtendendList<Cart> ct)
        {
            List<Cart.cType> cmrList = new List<Cart.cType>();
            foreach (string tmp in Enum.GetNames(typeof(Cart.cType)))
            {
                Cart.cType d = Cart.cType.Default;
                if (Enum.TryParse<Cart.cType>(tmp, out d))
                    cmrList.Add(d);
            }
            cmrList.Reverse();
            for (int i = 0; i <= ct.Count - 2; i++) // Not - 1, but - 2. Last item won't needed.
            {
                int diff = Structure.Abs(cmrList.IndexOf(ct[i].ccType) - cmrList.IndexOf(ct[i + 1].ccType)); // It works within three cards.
                if (diff != 1)
                    return false;
            }
            return true;
        }

        public static Info CheckWinning(ExtendendList<Structure> lst)
        {
            // Idea: Create a structure for the first to last, then for the second to the last and ...
            // If a structure fits to the here created structure then returns the structure.
            Info toRetrun = new Info();
            // Create mainList:
            ExtendendList<Cart.cType> mainList = new ExtendendList<Cart.cType>();
            foreach (string cmr in Enum.GetNames(typeof(Class.Cart.cType)))
                mainList.Add((Class.Cart.cType)Enum.Parse(typeof(Class.Cart.cType), cmr));
            mainList.Reverse();
            mainList.Remove(Cart.cType.Default);

            foreach (Structure curStr in lst)
            {
                // Filter active cars.
                ExtendendList<Cart> active = new ExtendendList<Cart>();
                foreach (Cart mCart in curStr.lstCards)
                    if (mCart.Active)
                        active.Add(mCart);
                for (int i = 0; i <= active.Count - 1; i++)
                {
                    ExtendendList<Cart> compare = new ExtendendList<Cart>();
                    for (int j = i; j <= active.Count - 1; j++)
                        compare.Add(active[j]);
                    // Compare these lists
                    if (Structure.CompareLists(mainList, compare))
                    {
                        toRetrun.CurrentStructure = curStr;
                        toRetrun.OK = true;
                        if (compare.Count > 0)
                            toRetrun.SelectedCart = compare[0];
                        return toRetrun; // We don't go on in the loop, we want to leave here and break leaves only one loop, but there are another, so it is easier.
                    }
                }
            }
            return toRetrun;
        }

        public static bool CompareLists(ExtendendList<Cart.cType> one, ExtendendList<Cart> two)
        {
            if (one.Count == two.Count)
            {
                for (int i = 0; i <= one.Count - 1; i++)
                {
                    if (one[i] != two[i].ccType)
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        public static int Abs(int value)
        {
            return -value;
           // return (value < 0) ? -value : value; (The new abs)
        }

        public static ExtendendList<Structure> CreateStructureList()
        {
            ExtendendList<Cart> mCarts = Class.Cart.CreateNewCarts();
            ExtendendList<Structure> mStructures = new ExtendendList<Class.Structure>();
            ExtendendList<Class.Cart> tmpLst = new ExtendendList<Class.Cart>();
            int index = 0, ct = 0;

            for (int i = 0; i <= 9; i++)
            {
                Structure.SType cType = (i >= 4) ? Structure.SType.Five : SType.Six;
                Structure str = new Structure(null, cType);
                int cCards = (i >= 4) ? 5 : 6;
                for (int c = 0; c <= cCards - 1; c++)
                {
                    Cart curCart = mCarts[index];
                    curCart.owner = str;
                    if (c == cCards - 1)
                        curCart.Active = true;
                    tmpLst.Add(curCart);
                    index++;
                    ct++;
                }
                str.lstCards = tmpLst.Clone();
                tmpLst.Clear();
                mStructures.Add(str);
            }

            Structure.OtherCards.Clear();
            for (int c = ct; c <= mCarts.Count - 1; c++)
                Structure.OtherCards.Add(mCarts[c]);
            return mStructures;
        }

        public static bool CanDistributeCards(ExtendendList<Structure> lst)
        {
            if (lst == null)
                return false;
            foreach (Structure str in lst)
            {
                if (str.lstCards.Count == 0)
                    return false;
            }
            return true;
        }

        public static ExtendendList<Tipp> ShowsAllTipps(ExtendendList<Structure> lst)
        {
            ExtendendList<Tipp> toReturn = new ExtendendList<Tipp>();

            foreach (Structure ms in lst)
            {
                ExtendendList<Cart> active = new ExtendendList<Cart>();
                foreach (Cart cmr in ms.lstCards)
                    if (cmr.Active)
                        active.Add(cmr);
                ExtendendList<Cart> proove = new ExtendendList<Cart>();
                ExtendendList<Cart> testLst = new ExtendendList<Cart>();
                bool okay = false;
                for (int i = 0; i <= active.Count - 1; i++)
                {
                    proove.Clear();
                    for (int j = i; j <= active.Count - 1; j++)
                        proove.Add(active[j]);

                    okay = Structure.CanMoveCards(proove);
                    if (okay)
                    {
                        if (okay)
                        {
                            // At first, we have have to check out, whether the structure fits to the last cart from another structure!
                            bool goOn = false;
                            foreach (Structure d1 in lst)
                            {
                                if (d1.lstCards.Count == 0)
                                    goOn = true;
                                else
                                {
                                    testLst.Clear();
                                    testLst.Add(d1.lstCards[d1.lstCards.Count - 1]);
                                    testLst.AddRange(proove);
                                    goOn = Structure.CanMoveCards(testLst);
                                    if (goOn)
                                    {
                                        foreach (Cart cs1 in testLst)
                                            cs1.IsTipp = true;
                                    }
                                }
                                if (goOn)
                                {
                                    if (testLst.Count != 0)
                                        foreach (Cart cs1 in proove)
                                            cs1.IsTipp = true;
                                }
                            }
                        }
                    }
                }
            }
            return toReturn;             
        }

        public struct Tipp
        {
            public ExtendendList<Cart> SelectedCards;

            public Tipp(ExtendendList<Cart> SelectedCards)
            {
                this.SelectedCards = SelectedCards;
            }

        }

        public static bool DistributeNewCars(ExtendendList<Structure> tmpLst)
        {
            if (Structure.CanDistributeCards(tmpLst))
            {
                if (Structure.OtherCards.Count != 0 && Structure.OtherCards.Count > 9)
                {
                    int count = 0;
                    ExtendendList<Cart> saved = new ExtendendList<Cart>();
                    foreach (Structure str in tmpLst)
                    {
                        Cart toAdd = Structure.OtherCards[count];
                        saved.Add(toAdd);
                        toAdd.Active = true;
                        str.lstCards.Add(toAdd);
                        count++;
                    }
                    for (int i = 0; i <= count - 1; i++)
                        Structure.OtherCards.Remove(saved[i]);
                    Structure.SetState(tmpLst, false);
                }
                return true;
            }
            else
                return false;
        }
    }
}