using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider.Class
{
    [Serializable]
    public class ExtendendList<T> : List<T>
    {
        public ExtendendList()
        { }

        public ExtendendList<T> Clone()
        {
            ExtendendList<T> tmpLst = new ExtendendList<T>();
            foreach (T tmp in base.ToArray())
                tmpLst.Add(tmp);
            return tmpLst;
        }
    }
}