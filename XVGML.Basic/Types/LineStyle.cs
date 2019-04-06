using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace XVGML.Basic.Types {
    public class LineStyle {
        public Single Width { get; set; }
        public Color Color { get; set; }

        public LineStyle() {
            Width = 1;
            Color = Color.Black;
        }
    }
}
