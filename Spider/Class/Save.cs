using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Spider.Class
{
    public class Save
    {
        public int Y = 15;
        public int Width = 81;
        public int Height = 109;
        public int Distance = 30;
        public int Distance2 = 20;

        public string Background;

        [XmlElement(Type = typeof(XmlColor))]
        public System.Drawing.Color SelectColor = System.Drawing.Color.Green;

        [XmlElement(Type = typeof(XmlColor))]
        public System.Drawing.Color ActiveCardsColor = System.Drawing.Color.Red;

        [XmlElement(Type = typeof(XmlColor))]
        public System.Drawing.Color TipColor = System.Drawing.Color.Blue;

        [XmlElement(Type = typeof(XmlColor))]
        public System.Drawing.Color FontColor = System.Drawing.Color.White;
    }
}
