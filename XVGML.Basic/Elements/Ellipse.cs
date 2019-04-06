using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using XVGML.Basic.Types;
using XVGML.Core;
using XVGML.Core.Elements;

namespace XVGML.Basic.Elements {
    class Ellipse : IGraphicElement {
        public Location Location { get; set; }
        public Types.Size Size { get; set; }
        public LineStyle Border { get; set; }
        public Padding Padding { get; set; }

        public Ellipse() {
            Location = new Location();
            Size = new Types.Size();
            Border = new LineStyle();
            Padding = new Padding();
        }

        public GraphicsPath Render(ICanvas canvas) {
            var halfBorder = Border.Width / 2;
            var borderPen = new Pen(Border.Width > 0 ? Border.Color : Color.Transparent, Border.Width);
            canvas.DrawEllipse(borderPen,
                Location.Left + halfBorder,
                Location.Top + halfBorder,
                Size.Width - Border.Width,
                Size.Height - Border.Width);
            return CalculateInnerBounds();
        }

        public SizeF RequiredSpace {
            get { return Size; }
        }

        private GraphicsPath CalculateInnerBounds() {
            var bounds = new GraphicsPath();
            bounds.AddEllipse(new RectangleF(
                Location.Left + Padding.Left + Border.Width,
                Location.Top + Padding.Top + Border.Width,
                Size.Width - Padding.Left - Padding.Right - 2*Border.Width,
                Size.Height - Padding.Top - Padding.Bottom - 2*Border.Width));
            return bounds;
        }
    }
}
