using System.Drawing;
using System.Drawing.Drawing2D;

namespace XVGML.Core.Elements {
    public interface IGraphicElement {
        /// <summary>
        /// Renders element to specified canvas.
        /// </summary>
        /// <param name="canvas">Specifies canvas to render element on.</param>
        /// <returns>Boundaries of inner space relative to parent canvas where child elements can be rendered.</returns>
        GraphicsPath Render(ICanvas canvas);

        /// <summary>
        /// Gets element's required space.
        /// Used when element is root.
        /// </summary>
        SizeF RequiredSpace { get; }
    }
}
