using System;

namespace ColorsLib
{
    class ColorInfo
    {
        public string NameColor { get; set; }
        public string HexColor { get; set; }
        public string RColor { get; set; }
        public string GColor { get; set; }
        public string BColor { get; set; }

        public override string ToString()
        {
            return (NameColor + ":" + HexColor + ":" + RColor + ":" + GColor + ":" + BColor);
        }
    }
}
