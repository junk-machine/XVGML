using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XVGML.Core.Elements;
using System.Drawing;
using System.Drawing.Drawing2D;
using XVGML.Core;

namespace XVGML.Basic.Elements.Fills {
    class Gradient : IGraphicElement {
        public Color From { get; set; }
        public Color To { get; set; }
        public Single Angle { get; set; }

        public Gradient() {
            From = Color.Black;
            To = Color.White;
        }

        public GraphicsPath Render(ICanvas canvas) {
            canvas.FillPath(
                new LinearGradientBrush(canvas.Boundaries.GetBounds(), From, To, Angle),
                canvas.Boundaries);
            return canvas.Boundaries;
        }

        public SizeF RequiredSpace {
            get { throw new InvalidOperationException("Fill can not be root element."); }
        }
    }
}
