using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Spider.Class.Render.Graphics
{
    public class Graphics : IGraphics
    {
        private System.Drawing.Graphics renderTarget;

        public Graphics(System.Drawing.Graphics renderTarget)
        {
            this.renderTarget = renderTarget;
        }

        public void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
        {
            this.renderTarget.DrawArc(pen, rect, startAngle, sweepAngle);
        }

        public void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
        {
            this.renderTarget.DrawArc(pen, rect, startAngle, sweepAngle);
        }

        public void DrawArc(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            this.renderTarget.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
        }

        public void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            this.renderTarget.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
        }

        public void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4)
        {
            this.renderTarget.DrawBezier(pen, pt1, pt2, pt3, pt4);
        }

        public void DrawBezier(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4)
        {
            this.renderTarget.DrawBezier(pen, pt1, pt2, pt3, pt4);
        }

        public void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            this.renderTarget.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
        }

        public void DrawBeziers(Pen pen, Point[] points)
        {
            this.renderTarget.DrawBeziers(pen, points);
        }

        public void DrawClosedCurve(Pen pen, Point[] points)
        {
            this.renderTarget.DrawClosedCurve(pen, points);
        }

        public void DrawClosedCurve(Pen pen, Point[] points, float tension, FillMode fillmode)
        {
            this.renderTarget.DrawClosedCurve(pen, points, tension, fillmode);
        }

        public void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode)
        {
            this.renderTarget.DrawClosedCurve(pen, points, tension, fillmode);
        }

        public void DrawCurve(Pen pen, PointF[] points)
        {
            this.renderTarget.DrawCurve(pen, points);
        }

        public void DrawCurve(Pen pen, Point[] points)
        {
            this.renderTarget.DrawCurve(pen, points);
        }

        public void DrawCurve(Pen pen, Point[] points, float tension)
        {
            this.renderTarget.DrawCurve(pen, points, tension);
        }

        public void DrawCurve(Pen pen, PointF[] points, float tension)
        {
            this.renderTarget.DrawCurve(pen, points, tension);
        }

        public void DrawCurve(Pen pen, Point[] points, int offset, int numberOfSegments, float tension)
        {
            this.renderTarget.DrawCurve(pen, points, offset, numberOfSegments, tension);
        }

        public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension)
        {
            this.renderTarget.DrawCurve(pen, points, offset, numberOfSegments, tension);
        }

        public void DrawEllipse(Pen pen, RectangleF rect)
        {
            this.renderTarget.DrawEllipse(pen, rect);
        }

        public void DrawEllipse(Pen pen, Rectangle rect)
        {
            this.renderTarget.DrawEllipse(pen, rect);
        }

        public void DrawEllipse(Pen pen, float x, float y, float width, float height)
        {
            this.renderTarget.DrawEllipse(pen, x, y, width, height);
        }

        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            this.renderTarget.DrawEllipse(pen, x, y, width, height);
        }

        public void DrawIcon(Icon icon, Rectangle targetRect)
        {
            this.renderTarget.DrawIcon(icon, targetRect);
        }

        public void DrawIcon(Icon icon, int x, int y)
        {
            this.renderTarget.DrawIcon(icon, x, y);
        }

        public void DrawIconUnstretched(Icon icon, Rectangle targetRect)
        {
            this.renderTarget.DrawIconUnstretched(icon, targetRect);
        }

        public void DrawImage(Image image, RectangleF rect)
        {
            this.renderTarget.DrawImage(image, rect);
        }

        public void DrawImage(Image image, Point point)
        {
            this.renderTarget.DrawImage(image, point);
        }

        public void DrawImage(Image image, PointF[] destPoints)
        {
            this.renderTarget.DrawImage(image, destPoints);
        }

        public void DrawImage(Image image, Point[] destPoints)
        {
            this.renderTarget.DrawImage(image, destPoints);
        }

        public void DrawImage(Image image, Rectangle rect)
        {
            this.renderTarget.DrawImage(image, rect);
        }

        public void DrawImage(Image image, PointF point)
        {
            this.renderTarget.DrawImage(image, point);
        }

        public void DrawImage(Image image, int x, int y)
        {
            this.renderTarget.DrawImage(image, x, y);
        }

        public void DrawImage(Image image, float x, float y)
        {
            this.renderTarget.DrawImage(image, x, y);
        }

        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit);
        }

        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit);
        }

        public void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, destRect, srcRect, srcUnit);
        }

        public void DrawImage(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, destRect, srcRect, srcUnit);
        }

        public void DrawImage(Image image, int x, int y, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, x, y, srcRect, srcUnit);
        }

        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr);
        }

        public void DrawImage(Image image, float x, float y, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, x, y, srcRect, srcUnit);
        }

        public void DrawImage(Image image, int x, int y, int width, int height)
        {
            this.renderTarget.DrawImage(image, x, y, width, height);
        }

        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr);
        }

        public void DrawImage(Image image, float x, float y, float width, float height)
        {
            this.renderTarget.DrawImage(image, x, y, width, height);
        }

        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
        }

        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
        }

        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback, int callbackData)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
        }

        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
        }

        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback, int callbackData)
        {
            this.renderTarget.DrawImage(image, destPoints, srcRect, srcUnit, imageAttr, callback);
        }

        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
        }

        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs);
        }

        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttr);
        }

        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttr, callback);
        }

        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback);
        }

        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback, IntPtr callbackData)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback, callbackData);
        }

        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback, IntPtr callbackData)
        {
            this.renderTarget.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, imageAttrs, callback, callbackData);
        }

        public void DrawImageUnscaled(Image image, Rectangle rect)
        {
            this.renderTarget.DrawImageUnscaled(image, rect);
        }

        public void DrawImageUnscaled(Image image, int x, int y)
        {
            this.renderTarget.DrawImageUnscaled(image, x, y);
        }

        public void DrawImageUnscaled(Image image, int x, int y, int width, int height)
        {
            this.renderTarget.DrawImageUnscaled(image, x, y, width, height);
        }

        public void DrawImageUnscaledAndClipped(Image image, Rectangle rect)
        {
            this.renderTarget.DrawImageUnscaledAndClipped(image, rect);
        }

        public void DrawLine(Pen pen, PointF pt1, PointF pt2)
        {
            this.renderTarget.DrawLine(pen, pt1, pt2);
        }

        public void DrawLine(Pen pen, Point pt1, Point pt2)
        {
            this.renderTarget.DrawLine(pen, pt1, pt2);
        }

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            this.renderTarget.DrawLine(pen, x1, y1, x2, y2);
        }

        public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
        {
            this.renderTarget.DrawLine(pen, x1, y1, x2, y2);
        }

        public void DrawLines(Pen pen, Point[] points)
        {
            this.renderTarget.DrawLines(pen, points);
        }

        public void DrawLines(Pen pen, PointF[] points)
        {
            this.renderTarget.DrawLines(pen, points);
        }

        public void DrawPath(Pen pen, GraphicsPath path)
        {
            this.renderTarget.DrawPath(pen, path);
        }

        public void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
        {
            this.renderTarget.DrawPie(pen, rect, startAngle, sweepAngle);
        }

        public void DrawPie(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
        {
            this.renderTarget.DrawPie(pen, rect, startAngle, sweepAngle);
        }

        public void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            this.renderTarget.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
        }

        public void DrawPie(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            this.renderTarget.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
        }

        public void DrawPolygon(Pen pen, PointF[] points)
        {
            this.renderTarget.DrawPolygon(pen, points);
        }

        public void DrawPolygon(Pen pen, Point[] points)
        {
            this.renderTarget.DrawPolygon(pen, points);
        }

        public void DrawRectangle(Pen pen, RectangleF rect)
        {
            this.renderTarget.DrawRectangle(pen, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height));
        }

        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            this.renderTarget.DrawRectangle(pen, rect);
        }

        public void DrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            this.renderTarget.DrawRectangle(pen, x, y, width, height);
        }

        public void DrawRectangle(Pen pen, float x, float y, float width, float height)
        {
            this.renderTarget.DrawRectangle(pen, x, y, width, height);
        }

        public void DrawRectangles(Pen pen, RectangleF[] rects)
        {
            this.renderTarget.DrawRectangles(pen, rects);
        }

        public void DrawRectangles(Pen pen, Rectangle[] rects)
        {
            this.renderTarget.DrawRectangles(pen, rects);
        }

        public void DrawString(string s, Font font, Brush brush, PointF point)
        {
            this.renderTarget.DrawString(s, font, brush, point);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle)
        {
            this.renderTarget.DrawString(s, font, brush, layoutRectangle);
        }

        public void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format)
        {
            this.renderTarget.DrawString(s, font, brush, point, format);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
        {
            this.renderTarget.DrawString(s, font, brush, layoutRectangle, format);
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y)
        {
            this.renderTarget.DrawString(s, font, brush, x, y);
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format)
        {
            this.renderTarget.DrawString(s, font, brush, x, y, format);
        }

        public void FillClosedCurve(Brush brush, PointF[] points)
        {
            this.renderTarget.FillClosedCurve(brush, points);
        }

        public void FillClosedCurve(Brush brush, Point[] points)
        {
            this.renderTarget.FillClosedCurve(brush, points);
        }

        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode)
        {
            this.renderTarget.FillClosedCurve(brush, points, fillmode);
        }

        public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode)
        {
            this.renderTarget.FillClosedCurve(brush, points, fillmode);
        }

        public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode, float tension)
        {
            this.renderTarget.FillClosedCurve(brush, points, fillmode, tension);
        }

        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension)
        {
            this.renderTarget.FillClosedCurve(brush, points, fillmode, tension);
        }

        public void FillEllipse(Brush brush, Rectangle rect)
        {
            this.renderTarget.FillEllipse(brush, rect);
        }

        public void FillEllipse(Brush brush, RectangleF rect)
        {
            this.renderTarget.FillEllipse(brush, rect);
        }

        public void FillEllipse(Brush brush, int x, int y, int width, int height)
        {
            this.renderTarget.FillEllipse(brush, x, y, width, height);
        }

        public void FillEllipse(Brush brush, float x, float y, float width, float height)
        {
            this.renderTarget.FillEllipse(brush, x, y, width, height);
        }

        public void FillPath(Brush brush, GraphicsPath path)
        {
            this.renderTarget.FillPath(brush, path);
        }

        public void FillPie(Brush brush, Rectangle rect, float startAngle, float sweepAngle)
        {
            this.renderTarget.FillPie(brush, rect, startAngle, sweepAngle);
        }

        public void FillPie(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            this.renderTarget.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
        }

        public void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            this.renderTarget.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
        }

        public void FillPolygon(Brush brush, Point[] points)
        {
            this.renderTarget.FillPolygon(brush, points);
        }

        public void FillPolygon(Brush brush, PointF[] points, FillMode fillMode)
        {
            this.renderTarget.FillPolygon(brush, points, fillMode);
        }

        public void FillPolygon(Brush brush, Point[] points, FillMode fillMode)
        {
            this.renderTarget.FillPolygon(brush, points, fillMode);
        }

        public void FillRectangle(Brush brush, Rectangle rect)
        {
            this.renderTarget.FillRectangle(brush, rect);
        }

        public void FillRectangle(Brush brush, RectangleF rect)
        {
            this.renderTarget.FillRectangle(brush, rect);
        }

        public void FillRectangle(Brush brush, int x, int y, int width, int height)
        {
            this.renderTarget.FillRectangle(brush, x, y, width, height);
        }

        public void FillRectangle(Brush brush, float x, float y, float width, float height)
        {
            this.renderTarget.FillRectangle(brush, x, y, width, height);
        }

        public void FillRectangles(Brush brush, RectangleF[] rects)
        {
            this.renderTarget.FillRectangles(brush, rects);
        }

        public void FillRectangles(Brush brush, Rectangle[] rects)
        {
            this.renderTarget.FillRectangles(brush, rects);
        }

        public void FillRegion(Brush brush, Region region)
        {
            this.renderTarget.FillRegion(brush, region);
        }
    }
}
