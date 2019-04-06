using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XVGML.Core {
    public interface ICanvas {
        object DrawingCore { get; }

        GraphicsPath Boundaries { get; set; }

        //
        // Summary:
        //     Draws an arc representing a portion of an ellipse specified by a System.Drawing.RectangleF
        //     structure.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the arc.
        //
        //   rect:
        //     System.Drawing.RectangleF structure that defines the boundaries of the ellipse.
        //
        //   startAngle:
        //     Angle in degrees measured clockwise from the x-axis to the starting point
        //     of the arc.
        //
        //   sweepAngle:
        //     Angle in degrees measured clockwise from the startAngle parameter to ending
        //     point of the arc.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null
        void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle);
        //
        // Summary:
        //     Draws an arc representing a portion of an ellipse specified by a pair of
        //     coordinates, a width, and a height.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the arc.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the rectangle that defines the
        //     ellipse.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the rectangle that defines the
        //     ellipse.
        //
        //   width:
        //     Width of the rectangle that defines the ellipse.
        //
        //   height:
        //     Height of the rectangle that defines the ellipse.
        //
        //   startAngle:
        //     Angle in degrees measured clockwise from the x-axis to the starting point
        //     of the arc.
        //
        //   sweepAngle:
        //     Angle in degrees measured clockwise from the startAngle parameter to ending
        //     point of the arc.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle);

        //
        // Summary:
        //     Draws a Bézier spline defined by four System.Drawing.PointF structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the curve.
        //
        //   pt1:
        //     System.Drawing.PointF structure that represents the starting point of the
        //     curve.
        //
        //   pt2:
        //     System.Drawing.PointF structure that represents the first control point for
        //     the curve.
        //
        //   pt3:
        //     System.Drawing.PointF structure that represents the second control point
        //     for the curve.
        //
        //   pt4:
        //     System.Drawing.PointF structure that represents the ending point of the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4);
        //
        // Summary:
        //     Draws a Bézier spline defined by four ordered pairs of coordinates that represent
        //     points.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the curve.
        //
        //   x1:
        //     The x-coordinate of the starting point of the curve.
        //
        //   y1:
        //     The y-coordinate of the starting point of the curve.
        //
        //   x2:
        //     The x-coordinate of the first control point of the curve.
        //
        //   y2:
        //     The y-coordinate of the first control point of the curve.
        //
        //   x3:
        //     The x-coordinate of the second control point of the curve.
        //
        //   y3:
        //     The y-coordinate of the second control point of the curve.
        //
        //   x4:
        //     The x-coordinate of the ending point of the curve.
        //
        //   y4:
        //     The y-coordinate of the ending point of the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4);
        //
        // Summary:
        //     Draws a series of Bézier splines from an array of System.Drawing.PointF structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that represent the points that
        //     determine the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawBeziers(Pen pen, PointF[] points);

        //
        // Summary:
        //     Draws a closed cardinal spline defined by an array of System.Drawing.PointF
        //     structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and height of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawClosedCurve(Pen pen, PointF[] points);
        //
        // Summary:
        //     Draws a closed cardinal spline defined by an array of System.Drawing.PointF
        //     structures using a specified tension.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and height of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        //   tension:
        //     Value greater than or equal to 0.0F that specifies the tension of the curve.
        //
        //   fillmode:
        //     Member of the System.Drawing.Drawing2D.FillMode enumeration that determines
        //     how the curve is filled. This parameter is required but is ignored.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode);
        
        //
        // Summary:
        //     Draws a cardinal spline through a specified array of System.Drawing.PointF
        //     structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and height of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawCurve(Pen pen, PointF[] points);
        //
        // Summary:
        //     Draws a cardinal spline through a specified array of System.Drawing.PointF
        //     structures using a specified tension.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and height of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that represent the points that
        //     define the curve.
        //
        //   tension:
        //     Value greater than or equal to 0.0F that specifies the tension of the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawCurve(Pen pen, PointF[] points, float tension);
        //
        // Summary:
        //     Draws a cardinal spline through a specified array of System.Drawing.PointF
        //     structures. The drawing begins offset from the beginning of the array.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and height of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        //   offset:
        //     Offset from the first element in the array of the points parameter to the
        //     starting point in the curve.
        //
        //   numberOfSegments:
        //     Number of segments after the starting point to include in the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments);
        //
        // Summary:
        //     Draws a cardinal spline through a specified array of System.Drawing.PointF
        //     structures using a specified tension. The drawing begins offset from the
        //     beginning of the array.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and height of the curve.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        //   offset:
        //     Offset from the first element in the array of the points parameter to the
        //     starting point in the curve.
        //
        //   numberOfSegments:
        //     Number of segments after the starting point to include in the curve.
        //
        //   tension:
        //     Value greater than or equal to 0.0F that specifies the tension of the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension);
        
        //
        // Summary:
        //     Draws an ellipse defined by a bounding System.Drawing.RectangleF.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the ellipse.
        //
        //   rect:
        //     System.Drawing.RectangleF structure that defines the boundaries of the ellipse.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawEllipse(Pen pen, RectangleF rect);
        //
        // Summary:
        //     Draws an ellipse defined by a bounding rectangle specified by a pair of coordinates,
        //     a height, and a width.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the ellipse.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse.
        //
        //   width:
        //     Width of the bounding rectangle that defines the ellipse.
        //
        //   height:
        //     Height of the bounding rectangle that defines the ellipse.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawEllipse(Pen pen, float x, float y, float width, float height);

        //
        // Summary:
        //     Draws the specified portion of the specified System.Drawing.Image at the
        //     specified location and with the specified size.
        //
        // Parameters:
        //   image:
        //     System.Drawing.Image to draw.
        //
        //   destRect:
        //     System.Drawing.RectangleF structure that specifies the location and size
        //     of the drawn image. The image is scaled to fit the rectangle.
        //
        //   srcRect:
        //     System.Drawing.RectangleF structure that specifies the portion of the image
        //     object to draw.
        //
        //   srcUnit:
        //     Member of the System.Drawing.GraphicsUnit enumeration that specifies the
        //     units of measure used by the srcRect parameter.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     image is null.
        void DrawImage(Image image, RectangleF destRect, RectangleF srcRect);

        //
        // Summary:
        //     Draws a line connecting two System.Drawing.PointF structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the line.
        //
        //   pt1:
        //     System.Drawing.PointF structure that represents the first point to connect.
        //
        //   pt2:
        //     System.Drawing.PointF structure that represents the second point to connect.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawLine(Pen pen, PointF pt1, PointF pt2);
        //
        // Summary:
        //     Draws a line connecting the two points specified by the coordinate pairs.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the line.
        //
        //   x1:
        //     The x-coordinate of the first point.
        //
        //   y1:
        //     The y-coordinate of the first point.
        //
        //   x2:
        //     The x-coordinate of the second point.
        //
        //   y2:
        //     The y-coordinate of the second point.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawLine(Pen pen, float x1, float y1, float x2, float y2);
        //
        // Summary:
        //     Draws a series of line segments that connect an array of System.Drawing.PointF
        //     structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the line
        //     segments.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that represent the points to connect.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawLines(Pen pen, PointF[] points);

        //
        // Summary:
        //     Draws a System.Drawing.Drawing2D.GraphicsPath.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the path.
        //
        //   path:
        //     System.Drawing.Drawing2D.GraphicsPath to draw.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-path is null.
        void DrawPath(Pen pen, GraphicsPath path);

        //
        // Summary:
        //     Draws a pie shape defined by an ellipse specified by a System.Drawing.RectangleF
        //     structure and two radial lines.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the pie
        //     shape.
        //
        //   rect:
        //     System.Drawing.RectangleF structure that represents the bounding rectangle
        //     that defines the ellipse from which the pie shape comes.
        //
        //   startAngle:
        //     Angle measured in degrees clockwise from the x-axis to the first side of
        //     the pie shape.
        //
        //   sweepAngle:
        //     Angle measured in degrees clockwise from the startAngle parameter to the
        //     second side of the pie shape.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle);
        //
        // Summary:
        //     Draws a pie shape defined by an ellipse specified by a coordinate pair, a
        //     width, a height, and two radial lines.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the pie
        //     shape.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse from which the pie shape comes.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse from which the pie shape comes.
        //
        //   width:
        //     Width of the bounding rectangle that defines the ellipse from which the pie
        //     shape comes.
        //
        //   height:
        //     Height of the bounding rectangle that defines the ellipse from which the
        //     pie shape comes.
        //
        //   startAngle:
        //     Angle measured in degrees clockwise from the x-axis to the first side of
        //     the pie shape.
        //
        //   sweepAngle:
        //     Angle measured in degrees clockwise from the startAngle parameter to the
        //     second side of the pie shape.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle);

        //
        // Summary:
        //     Draws a polygon defined by an array of System.Drawing.PointF structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the polygon.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that represent the vertices of
        //     the polygon.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-points is null.
        void DrawPolygon(Pen pen, PointF[] points);

        //
        // Summary:
        //     Draws a rectangle specified by a coordinate pair, a width, and a height.
        //
        // Parameters:
        //   pen:
        //     A System.Drawing.Pen that determines the color, width, and style of the rectangle.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the rectangle to draw.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the rectangle to draw.
        //
        //   width:
        //     The width of the rectangle to draw.
        //
        //   height:
        //     The height of the rectangle to draw.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.
        void DrawRectangle(Pen pen, float x, float y, float width, float height);

        //
        // Summary:
        //     Draws a series of rectangles specified by System.Drawing.RectangleF structures.
        //
        // Parameters:
        //   pen:
        //     System.Drawing.Pen that determines the color, width, and style of the outlines
        //     of the rectangles.
        //
        //   rects:
        //     Array of System.Drawing.RectangleF structures that represent the rectangles
        //     to draw.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-rects is null.
        void DrawRectangles(Pen pen, RectangleF[] rects);

        //
        // Summary:
        //     Draws the specified text string at the specified location with the specified
        //     System.Drawing.Brush and System.Drawing.Font objects.
        //
        // Parameters:
        //   s:
        //     String to draw.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   brush:
        //     System.Drawing.Brush that determines the color and texture of the drawn text.
        //
        //   point:
        //     System.Drawing.PointF structure that specifies the upper-left corner of the
        //     drawn text.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-s is null.
        void DrawString(string s, Font font, Brush brush, PointF point);
        //
        // Summary:
        //     Draws the specified text string in the specified rectangle with the specified
        //     System.Drawing.Brush and System.Drawing.Font objects.
        //
        // Parameters:
        //   s:
        //     String to draw.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   brush:
        //     System.Drawing.Brush that determines the color and texture of the drawn text.
        //
        //   layoutRectangle:
        //     System.Drawing.RectangleF structure that specifies the location of the drawn
        //     text.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-s is null.
        void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle);
        //
        // Summary:
        //     Draws the specified text string at the specified location with the specified
        //     System.Drawing.Brush and System.Drawing.Font objects.
        //
        // Parameters:
        //   s:
        //     String to draw.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   brush:
        //     System.Drawing.Brush that determines the color and texture of the drawn text.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the drawn text.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the drawn text.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-s is null.
        void DrawString(string s, Font font, Brush brush, float x, float y);
        //
        // Summary:
        //     Draws the specified text string at the specified location with the specified
        //     System.Drawing.Brush and System.Drawing.Font objects using the formatting
        //     attributes of the specified System.Drawing.StringFormat.
        //
        // Parameters:
        //   s:
        //     String to draw.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   brush:
        //     System.Drawing.Brush that determines the color and texture of the drawn text.
        //
        //   point:
        //     System.Drawing.PointF structure that specifies the upper-left corner of the
        //     drawn text.
        //
        //   format:
        //     System.Drawing.StringFormat that specifies formatting attributes, such as
        //     line spacing and alignment, that are applied to the drawn text.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-s is null.
        void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format);
        //
        // Summary:
        //     Draws the specified text string in the specified rectangle with the specified
        //     System.Drawing.Brush and System.Drawing.Font objects using the formatting
        //     attributes of the specified System.Drawing.StringFormat.
        //
        // Parameters:
        //   s:
        //     String to draw.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   brush:
        //     System.Drawing.Brush that determines the color and texture of the drawn text.
        //
        //   layoutRectangle:
        //     System.Drawing.RectangleF structure that specifies the location of the drawn
        //     text.
        //
        //   format:
        //     System.Drawing.StringFormat that specifies formatting attributes, such as
        //     line spacing and alignment, that are applied to the drawn text.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-s is null.
        void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format);
        //
        // Summary:
        //     Draws the specified text string at the specified location with the specified
        //     System.Drawing.Brush and System.Drawing.Font objects using the formatting
        //     attributes of the specified System.Drawing.StringFormat.
        //
        // Parameters:
        //   s:
        //     String to draw.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   brush:
        //     System.Drawing.Brush that determines the color and texture of the drawn text.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the drawn text.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the drawn text.
        //
        //   format:
        //     System.Drawing.StringFormat that specifies formatting attributes, such as
        //     line spacing and alignment, that are applied to the drawn text.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-s is null.
        void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format);
        
        
        //
        // Summary:
        //     Fills the interior of a closed cardinal spline curve defined by an array
        //     of System.Drawing.PointF structures.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-points is null.
        void FillClosedCurve(Brush brush, PointF[] points);
        //
        // Summary:
        //     Fills the interior of a closed cardinal spline curve defined by an array
        //     of System.Drawing.PointF structures using the specified fill mode.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        //   fillmode:
        //     Member of the System.Drawing.Drawing2D.FillMode enumeration that determines
        //     how the curve is filled.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-points is null.
        void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode);
        //
        // Summary:
        //     Fills the interior of a closed cardinal spline curve defined by an array
        //     of System.Drawing.PointF structures using the specified fill mode and tension.
        //
        // Parameters:
        //   brush:
        //     A System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that define the spline.
        //
        //   fillmode:
        //     Member of the System.Drawing.Drawing2D.FillMode enumeration that determines
        //     how the curve is filled.
        //
        //   tension:
        //     Value greater than or equal to 0.0F that specifies the tension of the curve.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-points is null.
        void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension);
        
        //
        // Summary:
        //     Fills the interior of an ellipse defined by a bounding rectangle specified
        //     by a System.Drawing.RectangleF structure.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   rect:
        //     System.Drawing.RectangleF structure that represents the bounding rectangle
        //     that defines the ellipse.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.
        void FillEllipse(Brush brush, RectangleF rect);
        //
        // Summary:
        //     Fills the interior of an ellipse defined by a bounding rectangle specified
        //     by a pair of coordinates, a width, and a height.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse.
        //
        //   width:
        //     Width of the bounding rectangle that defines the ellipse.
        //
        //   height:
        //     Height of the bounding rectangle that defines the ellipse.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.
        void FillEllipse(Brush brush, float x, float y, float width, float height);

        //
        // Summary:
        //     Fills the interior of a System.Drawing.Drawing2D.GraphicsPath.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   path:
        //     System.Drawing.Drawing2D.GraphicsPath that represents the path to fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     pen is null.-or-path is null.
        void FillPath(Brush brush, GraphicsPath path);
        
        //
        // Summary:
        //     Fills the interior of a pie section defined by an ellipse specified by a
        //     pair of coordinates, a width, a height, and two radial lines.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse from which the pie section comes.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the bounding rectangle that
        //     defines the ellipse from which the pie section comes.
        //
        //   width:
        //     Width of the bounding rectangle that defines the ellipse from which the pie
        //     section comes.
        //
        //   height:
        //     Height of the bounding rectangle that defines the ellipse from which the
        //     pie section comes.
        //
        //   startAngle:
        //     Angle in degrees measured clockwise from the x-axis to the first side of
        //     the pie section.
        //
        //   sweepAngle:
        //     Angle in degrees measured clockwise from the startAngle parameter to the
        //     second side of the pie section.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.
        void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle);
        
        //
        // Summary:
        //     Fills the interior of a polygon defined by an array of points specified by
        //     System.Drawing.PointF structures.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that represent the vertices of
        //     the polygon to fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-points is null.
        void FillPolygon(Brush brush, PointF[] points);
        //
        // Summary:
        //     Fills the interior of a polygon defined by an array of points specified by
        //     System.Drawing.PointF structures using the specified fill mode.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   points:
        //     Array of System.Drawing.PointF structures that represent the vertices of
        //     the polygon to fill.
        //
        //   fillMode:
        //     Member of the System.Drawing.Drawing2D.FillMode enumeration that determines
        //     the style of the fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-points is null.
        void FillPolygon(Brush brush, PointF[] points, FillMode fillMode);

        //
        // Summary:
        //     Fills the interior of a rectangle specified by a System.Drawing.RectangleF
        //     structure.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   rect:
        //     System.Drawing.RectangleF structure that represents the rectangle to fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.
        void FillRectangle(Brush brush, RectangleF rect);
        //
        // Summary:
        //     Fills the interior of a rectangle specified by a pair of coordinates, a width,
        //     and a height.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   x:
        //     The x-coordinate of the upper-left corner of the rectangle to fill.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the rectangle to fill.
        //
        //   width:
        //     Width of the rectangle to fill.
        //
        //   height:
        //     Height of the rectangle to fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.
        void FillRectangle(Brush brush, float x, float y, float width, float height);

        //
        // Summary:
        //     Fills the interiors of a series of rectangles specified by System.Drawing.RectangleF
        //     structures.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   rects:
        //     Array of System.Drawing.RectangleF structures that represent the rectangles
        //     to fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.
        void FillRectangles(Brush brush, RectangleF[] rects);

        //
        // Summary:
        //     Fills the interior of a System.Drawing.Region.
        //
        // Parameters:
        //   brush:
        //     System.Drawing.Brush that determines the characteristics of the fill.
        //
        //   region:
        //     System.Drawing.Region that represents the area to fill.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     brush is null.-or-region is null.
        void FillRegion(Brush brush, Region region);

        //
        // Summary:
        //     Indicates whether the specified System.Drawing.PointF structure is contained
        //     within the visible clip region of this System.Drawing.Graphics.
        //
        // Parameters:
        //   point:
        //     System.Drawing.PointF structure to test for visibility.
        //
        // Returns:
        //     true if the point specified by the point parameter is contained within the
        //     visible clip region of this System.Drawing.Graphics; otherwise, false.
        bool IsVisible(PointF point);
        //
        // Summary:
        //     Indicates whether the rectangle specified by a System.Drawing.RectangleF
        //     structure is contained within the visible clip region of this System.Drawing.Graphics.
        //
        // Parameters:
        //   rect:
        //     System.Drawing.RectangleF structure to test for visibility.
        //
        // Returns:
        //     true if the rectangle specified by the rect parameter is contained within
        //     the visible clip region of this System.Drawing.Graphics; otherwise, false.
        bool IsVisible(RectangleF rect);
        //
        // Summary:
        //     Indicates whether the point specified by a pair of coordinates is contained
        //     within the visible clip region of this System.Drawing.Graphics.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the point to test for visibility.
        //
        //   y:
        //     The y-coordinate of the point to test for visibility.
        //
        // Returns:
        //     true if the point defined by the x and y parameters is contained within the
        //     visible clip region of this System.Drawing.Graphics; otherwise, false.
        bool IsVisible(float x, float y);
        //
        // Summary:
        //     Indicates whether the rectangle specified by a pair of coordinates, a width,
        //     and a height is contained within the visible clip region of this System.Drawing.Graphics.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the upper-left corner of the rectangle to test for visibility.
        //
        //   y:
        //     The y-coordinate of the upper-left corner of the rectangle to test for visibility.
        //
        //   width:
        //     Width of the rectangle to test for visibility.
        //
        //   height:
        //     Height of the rectangle to test for visibility.
        //
        // Returns:
        //     true if the rectangle defined by the x, y, width, and height parameters is
        //     contained within the visible clip region of this System.Drawing.Graphics;
        //     otherwise, false.
        bool IsVisible(float x, float y, float width, float height);

        //
        // Summary:
        //     Measures the specified string when drawn with the specified System.Drawing.Font.
        //
        // Parameters:
        //   text:
        //     String to measure.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        // Returns:
        //     This method returns a System.Drawing.SizeF structure that represents the
        //     size, in the units specified by the System.Drawing.Graphics.PageUnit property,
        //     of the string specified by the text parameter as drawn with the font parameter.
        SizeF MeasureString(string text, Font font);
        //
        // Summary:
        //     Measures the specified string when drawn with the specified System.Drawing.Font
        //     within the specified layout area.
        //
        // Parameters:
        //   text:
        //     String to measure.
        //
        //   font:
        //     System.Drawing.Font defines the text format of the string.
        //
        //   layoutArea:
        //     System.Drawing.SizeF structure that specifies the maximum layout area for
        //     the text.
        //
        // Returns:
        //     This method returns a System.Drawing.SizeF structure that represents the
        //     size, in the units specified by the System.Drawing.Graphics.PageUnit property,
        //     of the string specified by the text parameter as drawn with the font parameter.
        SizeF MeasureString(string text, Font font, SizeF layoutArea);
        //
        // Summary:
        //     Measures the specified string when drawn with the specified System.Drawing.Font
        //     and formatted with the specified System.Drawing.StringFormat.
        //
        // Parameters:
        //   text:
        //     String to measure.
        //
        //   font:
        //     System.Drawing.Font defines the text format of the string.
        //
        //   origin:
        //     System.Drawing.PointF structure that represents the upper-left corner of
        //     the string.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat that represents formatting information, such
        //     as line spacing, for the string.
        //
        // Returns:
        //     This method returns a System.Drawing.SizeF structure that represents the
        //     size, in the units specified by the System.Drawing.Graphics.PageUnit property,
        //     of the string specified by the text parameter as drawn with the font parameter
        //     and the stringFormat parameter.
        SizeF MeasureString(string text, Font font, PointF origin, StringFormat stringFormat);
        //
        // Summary:
        //     Measures the specified string when drawn with the specified System.Drawing.Font
        //     and formatted with the specified System.Drawing.StringFormat.
        //
        // Parameters:
        //   text:
        //     String to measure.
        //
        //   font:
        //     System.Drawing.Font defines the text format of the string.
        //
        //   layoutArea:
        //     System.Drawing.SizeF structure that specifies the maximum layout area for
        //     the text.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat that represents formatting information, such
        //     as line spacing, for the string.
        //
        // Returns:
        //     This method returns a System.Drawing.SizeF structure that represents the
        //     size, in the units specified by the System.Drawing.Graphics.PageUnit property,
        //     of the string specified in the text parameter as drawn with the font parameter
        //     and the stringFormat parameter.
        SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat);
        //
        // Summary:
        //     Measures the specified string when drawn with the specified System.Drawing.Font
        //     and formatted with the specified System.Drawing.StringFormat.
        //
        // Parameters:
        //   text:
        //     String to measure.
        //
        //   font:
        //     System.Drawing.Font that defines the text format of the string.
        //
        //   layoutArea:
        //     System.Drawing.SizeF structure that specifies the maximum layout area for
        //     the text.
        //
        //   stringFormat:
        //     System.Drawing.StringFormat that represents formatting information, such
        //     as line spacing, for the string.
        //
        //   charactersFitted:
        //     Number of characters in the string.
        //
        //   linesFilled:
        //     Number of text lines in the string.
        //
        // Returns:
        //     This method returns a System.Drawing.SizeF structure that represents the
        //     size of the string, in the units specified by the System.Drawing.Graphics.PageUnit
        //     property, of the text parameter as drawn with the font parameter and the
        //     stringFormat parameter.
        SizeF MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled);
    }
}
