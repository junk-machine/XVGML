using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using XVGML.Core;
using XVGML.Core.Elements;

namespace XVGML.Basic.Elements.Fills {
    class Solid : IGraphicElement {
        public Color Color { get; set; }

        public GraphicsPath Render(ICanvas canvas) {
            canvas.FillPath(new SolidBrush(Color), canvas.Boundaries);
            return canvas.Boundaries;
        }

        public SizeF RequiredSpace {
            get { throw new InvalidOperationException("Fill can not be root element."); }
        }
    }
}
