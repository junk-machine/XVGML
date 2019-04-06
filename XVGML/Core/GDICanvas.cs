using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XVGML.Core {
    class GDICanvas : ICanvas, IDisposable {
        Bitmap bitmap;
        Graphics graphics;

        public GDICanvas(SizeF size) {
            bitmap = new Bitmap((int)size.Width, (int)size.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            graphics = Graphics.FromImage(bitmap);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GDICanvas() 
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                if (bitmap != null) {
                    bitmap.Dispose();
                    bitmap = null;
                }
                if (graphics != null) {
                    graphics.Dispose();
                    graphics = null;
                }
            }
        }

        #region ICanvas Members

        public object DrawingCore {
            get { return graphics; }
        }

        private GraphicsPath bounds;
        public GraphicsPath Boundaries {
            get { return bounds; }
            set {
                graphics.Clip = new Region(value);
                bounds = value;
            }
        }

        internal Image Picture {
            get { return bitmap; }
        }

        public void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle) {
            graphics.DrawArc(pen, rect, startAngle, sweepAngle);
        }

        public void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle) {
            graphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
        }

        public void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4) {
            graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);
        }

        public void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4) {
            graphics.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
        }

        public void DrawBeziers(Pen pen, PointF[] points) {
            graphics.DrawBeziers(pen, points);
        }

        public void DrawClosedCurve(Pen pen, PointF[] points) {
            graphics.DrawClosedCurve(pen, points);
        }

        public void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode) {
            graphics.DrawClosedCurve(pen, points, tension, fillmode);
        }

        public void DrawCurve(Pen pen, PointF[] points) {
            graphics.DrawCurve(pen, points);
        }

        public void DrawCurve(Pen pen, PointF[] points, float tension) {
            graphics.DrawCurve(pen, points, tension);
        }

        public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments) {
            graphics.DrawCurve(pen, points, offset, numberOfSegments);
        }

        public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension) {
            graphics.DrawCurve(pen, points, offset, numberOfSegments, tension);
        }

        public void DrawEllipse(Pen pen, RectangleF rect) {
            graphics.DrawEllipse(pen, rect);
        }

        public void DrawEllipse(Pen pen, float x, float y, float width, float height) {
            graphics.DrawEllipse(pen, x, y, width, height);
        }

        public void DrawImage(Image image, RectangleF destRect, RectangleF srcRect) {
            graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
        }

        public void DrawLine(Pen pen, PointF pt1, PointF pt2) {
            graphics.DrawLine(pen, pt1, pt2);
        }

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2) {
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        public void DrawLines(Pen pen, PointF[] points) {
            graphics.DrawLines(pen, points);
        }

        public void DrawPath(Pen pen, GraphicsPath path) {
            graphics.DrawPath(pen, path);
        }

        public void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle) {
            graphics.DrawPie(pen, rect, startAngle, sweepAngle);
        }

        public void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle) {
            graphics.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
        }

        public void DrawPolygon(Pen pen, PointF[] points) {
            graphics.DrawPolygon(pen, points);
        }

        public void DrawRectangle(Pen pen, float x, float y, float width, float height) {
            graphics.DrawRectangle(pen, x, y, width, height);
        }

        public void DrawRectangles(Pen pen, RectangleF[] rects) {
            graphics.DrawRectangles(pen, rects);
        }

        public void DrawString(string s, Font font, Brush brush, PointF point) {
            graphics.DrawString(s, font, brush, point);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle) {
            graphics.DrawString(s, font, brush, layoutRectangle);
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y) {
            graphics.DrawString(s, font, brush, x, y);
        }

        public void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format) {
            graphics.DrawString(s, font, brush, point, format);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format) {
            graphics.DrawString(s, font, brush, layoutRectangle, format);
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format) {
            graphics.DrawString(s, font, brush, x, y, format);
        }

        public void FillClosedCurve(Brush brush, PointF[] points) {
            graphics.FillClosedCurve(brush, points);
        }

        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode) {
            graphics.FillClosedCurve(brush, points, fillmode);
        }

        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension) {
            graphics.FillClosedCurve(brush, points, fillmode, tension);
        }

        public void FillEllipse(Brush brush, RectangleF rect) {
            graphics.FillEllipse(brush, rect);
        }

        public void FillEllipse(Brush brush, float x, float y, float width, float height) {
            graphics.FillEllipse(brush, x, y, width, height);
        }

        public void FillPath(Brush brush, GraphicsPath path) {
            graphics.FillPath(brush, path);
        }

        public void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle) {
            graphics.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
        }

        public void FillPolygon(Brush brush, PointF[] points) {
            graphics.FillPolygon(brush, points);
        }

        public void FillPolygon(Brush brush, PointF[] points, FillMode fillMode) {
            graphics.FillPolygon(brush, points, fillMode);
        }

        public void FillRectangle(Brush brush, RectangleF rect) {
            graphics.FillRectangle(brush, rect);
        }

        public void FillRectangle(Brush brush, float x, float y, float width, float height) {
            graphics.FillRectangle(brush, x, y, width, height);
        }

        public void FillRectangles(Brush brush, RectangleF[] rects) {
            graphics.FillRectangles(brush, rects);
        }

        public void FillRegion(Brush brush, Region region) {
            graphics.FillRegion(brush, region);
        }

        public bool IsVisible(PointF point) {
            return graphics.IsVisible(point);
        }

        public bool IsVisible(RectangleF rect) {
            return graphics.IsVisible(rect);
        }

        public bool IsVisible(float x, float y) {
            return graphics.IsVisible(x, y);
        }

        public bool IsVisible(float x, float y, float width, float height) {
            return graphics.IsVisible(x, y, width, height);
        }

        public SizeF MeasureString(string text, Font font) {
            return graphics.MeasureString(text, font);
        }

        public SizeF MeasureString(string text, Font font, SizeF layoutArea) {
            return graphics.MeasureString(text, font, layoutArea);
        }

        public SizeF MeasureString(string text, Font font, PointF origin, StringFormat stringFormat) {
            return graphics.MeasureString(text, font, origin, stringFormat);
        }

        public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat) {
            return graphics.MeasureString(text, font, layoutArea, stringFormat);
        }

        public SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled) {
            return graphics.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
        }

        #endregion
    }
}
