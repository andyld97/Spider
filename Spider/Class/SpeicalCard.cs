using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Spider.Class
{
    [Serializable]
    public class SpecialCard : Cart
    {
        public SpecialCard(Cart.GameMode mode) : base(cType.Default, mode)
        {

        }

        public SpecialCard()
        { }

        public override Image ToImage()
        {
            return Image.FromFile(System.IO.Path.Combine(new string[] { Application.StartupPath, "Images", base.GameMode_.ToString(), "S.png" }));
        }
    }
}
