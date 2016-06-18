using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Spider.Class.Render.Graphics
{
    public interface IGraphics
    {
        void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle);

        void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle);

        void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle);

        void DrawArc(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle);

        void DrawBezier(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4);

        void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4);

        void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4);

        void DrawBeziers(Pen pen, Point[] points);

        void DrawClosedCurve(Pen pen, Point[] points);

        void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode);

        void DrawClosedCurve(Pen pen, Point[] points, float tension, FillMode fillmode);

        void DrawCurve(Pen pen, Point[] points);

        void DrawCurve(Pen pen, PointF[] points);

        void DrawCurve(Pen pen, PointF[] points, float tension);

        void DrawCurve(Pen pen, Point[] points, float tension);

        void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension);

        void DrawCurve(Pen pen, Point[] points, int offset, int numberOfSegments, float tension);

        void DrawEllipse(Pen pen, Rectangle rect);

        void DrawEllipse(Pen pen, RectangleF rect);

        void DrawEllipse(Pen pen, int x, int y, int width, int height);

        void DrawEllipse(Pen pen, float x, float y, float width, float height);

        void DrawIcon(Icon icon, Rectangle targetRect);

        void DrawIcon(Icon icon, int x, int y);

        void DrawIconUnstretched(Icon icon, Rectangle targetRect);

        void DrawImage(Image image, PointF point);

        void DrawImage(Image image, Rectangle rect);

        void DrawImage(Image image, PointF[] destPoints);

        void DrawImage(Image image, Point[] destPoints);

        void DrawImage(Image image, RectangleF rect);

        void DrawImage(Image image, Point point);

        void DrawImage(Image image, float x, float y);

        void DrawImage(Image image, int x, int y);

        void DrawImage(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit);

        void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit);

        void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit);

        void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit);

        void DrawImage(Image image, float x, float y, float width, float height);

        void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr);

        void DrawImage(Image image, int x, int y, int width, int height);

        void DrawImage(Image image, int x, int y, Rectangle srcRect, GraphicsUnit srcUnit);

        void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr);

        void DrawImage(Image image, float x, float y, RectangleF srcRect, GraphicsUnit srcUnit);

        void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback);

        void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback);

        void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit);

        void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback, int callbackData);

        void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit);

        void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback, int callbackData);

        void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr);

        void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs);

        void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback);

        void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback);

        void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback, IntPtr callbackData);

        void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback, IntPtr callbackData);

        void DrawImageUnscaled(Image image, Rectangle rect);

        void DrawImageUnscaled(Image image, int x, int y);

        void DrawImageUnscaled(Image image, int x, int y, int width, int height);

        void DrawImageUnscaledAndClipped(Image image, Rectangle rect);

        void DrawLine(Pen pen, Point pt1, Point pt2);

        void DrawLine(Pen pen, PointF pt1, PointF pt2);

        void DrawLine(Pen pen, int x1, int y1, int x2, int y2);

        void DrawLine(Pen pen, float x1, float y1, float x2, float y2);

        void DrawLines(Pen pen, PointF[] points);

        void DrawLines(Pen pen, Point[] points);

        void DrawPath(Pen pen, GraphicsPath path);

        void DrawPie(Pen pen, Rectangle rect, float startAngle, float sweepAngle);

        void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle);

        void DrawPie(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle);

        void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle);

        void DrawPolygon(Pen pen, Point[] points);

        void DrawPolygon(Pen pen, PointF[] points);

        void DrawRectangle(Pen pen, Rectangle rect);

        void DrawRectangle(Pen pen, RectangleF rect);

        void DrawRectangle(Pen pen, float x, float y, float width, float height);

        void DrawRectangle(Pen pen, int x, int y, int width, int height);

        void DrawRectangles(Pen pen, Rectangle[] rects);

        void DrawRectangles(Pen pen, RectangleF[] rects);

        void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle);

        void DrawString(string s, Font font, Brush brush, PointF point);

        void DrawString(string s, Font font, Brush brush, float x, float y);

        void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format);

        void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format);

        void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format);

        void FillClosedCurve(Brush brush, Point[] points);

        void FillClosedCurve(Brush brush, PointF[] points);

        void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode);

        void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode);

        void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension);

        void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode, float tension);

        void FillEllipse(Brush brush, RectangleF rect);

        void FillEllipse(Brush brush, Rectangle rect);

        void FillEllipse(Brush brush, float x, float y, float width, float height);

        void FillEllipse(Brush brush, int x, int y, int width, int height);

        void FillPath(Brush brush, GraphicsPath path);

        void FillPie(Brush brush, Rectangle rect, float startAngle, float sweepAngle);

        void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle);

        void FillPie(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle);

        void FillPolygon(Brush brush, Point[] points);

        void FillPolygon(Brush brush, Point[] points, FillMode fillMode);

        void FillPolygon(Brush brush, PointF[] points, FillMode fillMode);

        void FillRectangle(Brush brush, RectangleF rect);

        void FillRectangle(Brush brush, Rectangle rect);

        void FillRectangle(Brush brush, float x, float y, float width, float height);

        void FillRectangle(Brush brush, int x, int y, int width, int height);

        void FillRectangles(Brush brush, Rectangle[] rects);

        void FillRectangles(Brush brush, RectangleF[] rects);

        void FillRegion(Brush brush, Region region);
    }
}
