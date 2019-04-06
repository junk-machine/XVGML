using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using XVGML.Core;
using XVGML.Core.Elements;
using XVGML.Basic.Types;

namespace XVGML.Basic.Elements {
    class Label : IGraphicElement {
        public Location Location { get; set; }
        public Font Font { get; set; }
        public Color Color { get; set; }
        public String Text { get; set; }

        public Label() {
            Location = new Location();
            Font = new Font(FontFamily.GenericSerif, 10);
            Color = Color.Black;
        }

        public GraphicsPath Render(ICanvas canvas) {
            canvas.DrawString(Text, Font, new SolidBrush(Color), Location);
            return CalculateInnerBounds();
        }

        public SizeF RequiredSpace {
            get { throw new InvalidOperationException("Label can not be root element."); }
        }

        private GraphicsPath CalculateInnerBounds() {
            return new GraphicsPath();
        }
    }
}
