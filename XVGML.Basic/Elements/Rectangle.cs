using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XVGML.Core.Elements;
using System.Drawing.Drawing2D;
using System.Drawing;
using XVGML.Core;
using XVGML.Basic.Types;

namespace XVGML.Basic.Elements {
    class Rectangle : IGraphicElement {
        public Location Location { get; set; }
        public Types.Size Size { get; set; }
        public LineStyle Border { get; set; }
        public Padding Padding { get; set; }

        public Rectangle() {
            Location = new Location();
            Size = new Types.Size();
            Border = new LineStyle();
            Padding = new Padding();
        }

        public GraphicsPath Render(ICanvas canvas) {
            var halfBorder = Border.Width > 1 ? Border.Width / 2 : 0; // Fix for 0.5
            var borderPen = new Pen(Border.Width > 0 ? Border.Color : Color.Transparent, Border.Width);
            canvas.DrawRectangle(borderPen,
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
            bounds.AddRectangle(new RectangleF(
                Location.Left + Padding.Left + Border.Width,
                Location.Top + Padding.Top + Border.Width,
                Size.Width - Padding.Left - Padding.Right - 2*Border.Width,
                Size.Height - Padding.Top - Padding.Bottom - 2 * Border.Width));
            return bounds;
        }
    }
}
