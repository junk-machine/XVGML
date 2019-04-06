using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using XVGML.Basic.Types;
using XVGML.Core;
using XVGML.Core.Elements;

namespace XVGML.Basic.Elements {
    class Line : IGraphicElement {
        public PointF From { get; set; }
        public PointF To { get; set; }
        public LineStyle Style { get; set; }

        public Line() {
            Style = new LineStyle();
        }

        public GraphicsPath Render(ICanvas canvas) {
            var pen = new Pen(Style.Width > 0 ? Style.Color : Color.Transparent, Style.Width);
            canvas.DrawLine(pen, From, To);
            return CalculateInnerBounds();
        }

        public SizeF RequiredSpace {
            get { throw new InvalidOperationException("Line can not be root element."); }
        }

        private GraphicsPath CalculateInnerBounds() {
            return new GraphicsPath();
        }
    }
}
