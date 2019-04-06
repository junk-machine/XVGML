using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using XVGML.Log;
using XVGML.Core;
using XVGML.Core.Elements;

namespace XVGML {
    public class LayoutRenderer {
        public Image Render(LayoutElement element) {
            var canvas = new GDICanvas(element.Presentation.RequiredSpace);
            this.Render(element, canvas);
            return canvas.Picture;
        }

        private void Render(LayoutElement element, ICanvas canvas) {
            try {
                var innerBoundaries = element.Presentation.Render(canvas);

                if (innerBoundaries == null) return;
                var innerCanvasPosition = innerBoundaries.GetBounds();
                if (innerCanvasPosition.IsEmpty) return;

                var innerCanvas = new GDICanvas(innerCanvasPosition.Size);
                innerCanvas.Boundaries = TransformBoundariesToTopLeft(innerBoundaries);
                foreach (var child in element.Children) {
                    Render(child, innerCanvas);
                    var picture = innerCanvas.Picture;
                    canvas.DrawImage(picture,
                        new RectangleF(innerCanvasPosition.Left, innerCanvasPosition.Top,
                            innerCanvasPosition.Width, innerCanvasPosition.Height),
                        new RectangleF(0, 0, picture.Width, picture.Height));
                }
            } catch (Exception ex) {
                var failedImage = GetFailedRenderImage(canvas.Boundaries.GetBounds().Size);
                canvas.DrawImage(failedImage,
                    new RectangleF(0, 0, failedImage.Width, failedImage.Height),
                    new RectangleF(0, 0, failedImage.Width, failedImage.Height));
                LogPolicy.LogException(ex);
            }
        }

        private GraphicsPath TransformBoundariesToTopLeft(GraphicsPath boundaries) {
            var newBoundaries = (GraphicsPath)boundaries.Clone();
            newBoundaries.Transform(
                new Matrix(1, 0,
                           0, 1,
                           -boundaries.GetBounds().Left, -boundaries.GetBounds().Top)
            );
            return newBoundaries;
        }

        private Image GetFailedRenderImage(SizeF size) {
            Image image = new Bitmap((int)size.Width, (int)size.Height,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new PointF(size.Width, size.Height));
            graphics.DrawLine(new Pen(Color.Red, 2), new PointF(size.Width, 0), new PointF(0, size.Height));
            return image;
        }
    }
}
