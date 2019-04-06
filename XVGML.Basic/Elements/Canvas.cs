using System.Drawing.Drawing2D;
using System.Drawing;
using XVGML.Core;
using XVGML.Core.Elements;

namespace XVGML.Basic.Elements {
    class Canvas : IGraphicElement {
        public Types.Size Size { get; set; }
        public Color Background { get; set; }

        public Canvas() {
            Size = new Types.Size();
        }

        public GraphicsPath Render(ICanvas canvas) {
            canvas.FillRectangle(new SolidBrush(Background), 0, 0, Size.Width, Size.Height);
            return CalculateInnerBounds();
        }

        public SizeF RequiredSpace {
            get { return Size; }
        }

        private GraphicsPath CalculateInnerBounds() {
            var bounds = new GraphicsPath();
            bounds.AddRectangle(new RectangleF(0, 0, Size.Width, Size.Height));
            return bounds;
        }
    }
}
