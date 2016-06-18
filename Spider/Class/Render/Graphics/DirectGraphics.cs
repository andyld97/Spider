using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Spider.Class.Render.Graphics
{
    /// <summary>
    /// Translator from GDI to SlimDX
    /// </summary>
    public class DirectGraphics : IGraphics
    {
        private SlimDX.Direct2D.WindowRenderTarget renderTarget;
        private List<Bitmap> gr = new List<Bitmap>();
        private List<SlimDX.Direct2D.Bitmap> gb = new List<SlimDX.Direct2D.Bitmap>();
        private SlimDX.DirectWrite.Factory m;

        public DirectGraphics(SlimDX.Direct2D.WindowRenderTarget renderTarget)
        {
            this.renderTarget = renderTarget;
            try
            {
                m = new SlimDX.DirectWrite.Factory(SlimDX.DirectWrite.FactoryType.Shared);
            }
            catch { }
        }

        /// <summary>
        /// Releases the saved images
        /// </summary>
        public void Clear()
        {
            this.gr.Clear();
            this.gb.Clear();
        }

        private SlimDX.Direct2D.Bitmap loadBitmap(Bitmap drawingBitmap)
        {
            SlimDX.Direct2D.Bitmap result = null;

            if (drawingBitmap == null)
                return null;

            if (gr.Contains(drawingBitmap))
                return gb[gr.IndexOf(drawingBitmap)];
            else
                gr.Add(drawingBitmap);

            //Lock the gdi resource
            BitmapData drawingBitmapData = drawingBitmap.LockBits(
            new Rectangle(0, 0, drawingBitmap.Width, drawingBitmap.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

            //Prepare loading the image from gdi resource
            SlimDX.DataStream dataStream = new SlimDX.DataStream(drawingBitmapData.Scan0, drawingBitmapData.Stride * drawingBitmapData.Height, true, false);
            SlimDX.Direct2D.BitmapProperties properties = new SlimDX.Direct2D.BitmapProperties();
            properties.PixelFormat = new SlimDX.Direct2D.PixelFormat(SlimDX.DXGI.Format.B8G8R8A8_UNorm, SlimDX.Direct2D.AlphaMode.Premultiplied);
            //Load the image from the gdi resource
            result = new SlimDX.Direct2D.Bitmap(renderTarget, new Size(drawingBitmap.Width, drawingBitmap.Height), dataStream, drawingBitmapData.Stride, properties);

            //Unlock the gdi resource
            drawingBitmap.UnlockBits(drawingBitmapData);
            gb.Add(result);
            return result;
        }

        public void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        public void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        public void DrawArc(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            throw new NotImplementedException();
        }

        public void DrawArc(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        public void DrawBezier(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4)
        {
            throw new NotImplementedException();
        }

        public void DrawBezier(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4)
        {
            throw new NotImplementedException();
        }

        public void DrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            throw new NotImplementedException();
        }

        public void DrawBeziers(Pen pen, Point[] points)
        {
            throw new NotImplementedException();
        }

        public void DrawClosedCurve(Pen pen, Point[] points)
        {
            throw new NotImplementedException();
        }

        public void DrawClosedCurve(Pen pen, Point[] points, float tension, FillMode fillmode)
        {
            throw new NotImplementedException();
        }

        public void DrawClosedCurve(Pen pen, PointF[] points, float tension, FillMode fillmode)
        {
            throw new NotImplementedException();
        }

        public void DrawCurve(Pen pen, PointF[] points)
        {
            throw new NotImplementedException();
        }

        public void DrawCurve(Pen pen, Point[] points)
        {
            throw new NotImplementedException();
        }

        public void DrawCurve(Pen pen, Point[] points, float tension)
        {
            throw new NotImplementedException();
        }

        public void DrawCurve(Pen pen, PointF[] points, float tension)
        {
            throw new NotImplementedException();
        }

        public void DrawCurve(Pen pen, Point[] points, int offset, int numberOfSegments, float tension)
        {
            throw new NotImplementedException();
        }

        public void DrawCurve(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension)
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse(Pen pen, RectangleF rect)
        {
            this.renderTarget.DrawEllipse(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(pen.Color)), new SlimDX.Direct2D.Ellipse() { RadiusX = rect.Width / 2F, RadiusY = rect.Height / 2F, Center = new PointF(rect.Width / 2F, rect.Height / 2F) });
        }

        public void DrawEllipse(Pen pen, Rectangle rect)
        {
            this.DrawEllipse(pen, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height));
        }

        public void DrawEllipse(Pen pen, float x, float y, float width, float height)
        {
            this.DrawEllipse(pen, new RectangleF(x, y, width, height));
        }

        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            this.DrawEllipse(pen, new Rectangle(x, y, width, height));
        }

        public void DrawIcon(Icon icon, Rectangle targetRect)
        {
            Bitmap currentBitmap = new Bitmap(icon.Width, icon.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(currentBitmap);

            g.DrawIcon(icon, new Rectangle(0, 0, targetRect.Width, targetRect.Height));
            this.DrawImage(currentBitmap, targetRect);

            currentBitmap.Dispose();
        }

        public void DrawIcon(Icon icon, int x, int y)
        {
            this.DrawIcon(icon, new Rectangle(x, y, icon.Width, icon.Height));
        }

        public void DrawIconUnstretched(Icon icon, Rectangle targetRect)
        {
            Bitmap currentBitmap = new Bitmap(icon.Width, icon.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(currentBitmap);

            g.DrawIconUnstretched(icon, new Rectangle(0, 0, targetRect.Width, targetRect.Height));
            this.DrawImage(currentBitmap, targetRect);

         //   currentBitmap.Dispose();
        }

        public void DrawImage(Image image, RectangleF rect)
        {
            this.renderTarget.DrawBitmap(this.loadBitmap(image as Bitmap), rect);
        }

        public void DrawImage(Image image, Point point)
        {
            this.DrawImage(image, new Rectangle(point.X, point.Y, image.Width, image.Height));
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        public void DrawImage(Image image, PointF[] destPoints)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        public void DrawImage(Image image, Point[] destPoints)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(Image image, Rectangle rect)
        {
            this.renderTarget.DrawBitmap(this.loadBitmap(image as Bitmap), rect);
        }

        public void DrawImage(Image image, PointF point)
        {
            this.DrawImage(image, new RectangleF(point.X, point.Y, (float)image.Width, (float)image.Height));
        }

        public void DrawImage(Image image, int x, int y)
        {
            this.DrawImage(image, new Point(x, y));
        }

        public void DrawImage(Image image, float x, float y)
        {
            this.DrawImage(image, new PointF(x, y));
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, int x, int y, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, float x, float y, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(Image image, int x, int y, int width, int height)
        {
            this.DrawImage(image, new Rectangle(x, y, width, height));
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            throw new NotImplementedException();
        }

        public void DrawImage(Image image, float x, float y, float width, float height)
        {
            this.DrawImage(image, new RectangleF(x, y, width, height));
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        /// <param name="callback"></param>
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        /// <param name="callback"></param>
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        /// <param name="callback"></param>
        /// <param name="callbackData"></param>
        public void DrawImage(Image image, PointF[] destPoints, RectangleF srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback, int callbackData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destPoints"></param>
        /// <param name="srcRect"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        /// <param name="callback"></param>
        /// <param name="callbackData"></param>
        public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback, int callbackData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttrs"></param>
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttr"></param>
        /// <param name="callback"></param>
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr, System.Drawing.Graphics.DrawImageAbort callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttrs"></param>
        /// <param name="callback"></param>
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttrs"></param>
        /// <param name="callback"></param>
        /// <param name="callbackData"></param>
        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback, IntPtr callbackData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="image"></param>
        /// <param name="destRect"></param>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="srcUnit"></param>
        /// <param name="imageAttrs"></param>
        /// <param name="callback"></param>
        /// <param name="callbackData"></param>
        public void DrawImage(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttrs, System.Drawing.Graphics.DrawImageAbort callback, IntPtr callbackData)
        {
            throw new NotImplementedException();
        }

        public void DrawImageUnscaled(Image image, Rectangle rect)
        {
            Bitmap currentBitmap = new Bitmap(rect.Width, rect.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(currentBitmap);
            g.DrawImageUnscaled(image, new Rectangle(0, 0, rect.Width, rect.Height));

            this.DrawImage(currentBitmap, rect);
        }

        public void DrawImageUnscaled(Image image, int x, int y)
        {
            this.DrawImageUnscaled(image, new Rectangle(x, y, image.Width, image.Height));
        }

        public void DrawImageUnscaled(Image image, int x, int y, int width, int height)
        {
            this.DrawImageUnscaled(image, new Rectangle(x, y, width, height));
        }

        public void DrawImageUnscaledAndClipped(Image image, Rectangle rect)
        {
            Bitmap currentBitmap = new Bitmap(rect.Width, rect.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(currentBitmap);
            g.DrawImageUnscaledAndClipped(image, new Rectangle(0, 0, rect.Width, rect.Height));

            this.DrawImage(currentBitmap, rect);
        }

        public void DrawLine(Pen pen, PointF pt1, PointF pt2)
        {
            this.renderTarget.DrawLine(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(pen.Color)), pt1, pt2, pen.Width);
        }

        public void DrawLine(Pen pen, Point pt1, Point pt2)
        {
            this.DrawLine(pen, new PointF((int)pt1.X, (int)pt1.Y), new PointF((int)pt2.X, (int)pt2.Y));
        }

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            this.DrawLine(pen, new PointF(x1, y2), new PointF(x2, y2));
        }

        public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
        {
            this.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
        }

        public void DrawLines(Pen pen, PointF[] points)
        {
            if (points.Length % 2 == 0)
            {
                for (int i = 0; i <= points.Length - 2; i++)
                    this.DrawLine(pen, points[i], points[i + 1]);
            }
        }

        public void DrawLines(Pen pen, Point[] points)
        {
            if (points.Length % 2 == 0)
            {
                for (int i = 0; i <= points.Length - 2; i++)
                    this.DrawLine(pen, points[i], points[i + 1]);
            }
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="path"></param>
        public void DrawPath(Pen pen, GraphicsPath path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="rect"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void DrawPie(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="rect"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void DrawPie(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void DrawPie(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void DrawPie(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public void DrawPolygon(Pen pen, PointF[] points)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public void DrawPolygon(Pen pen, Point[] points)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            this.renderTarget.DrawRectangle(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(pen.Color)), rect);
        }

        public void DrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            this.DrawRectangle(pen, new Rectangle(x, y, width, height));
        }

        public void DrawRectangle(Pen pen, RectangleF rect)
        {
            this.renderTarget.DrawRectangle(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(pen.Color)), rect);
        }

        public void DrawRectangle(Pen pen, float x, float y, float width, float height)
        {
            this.DrawRectangle(pen, new RectangleF(x, y, width, height));
        }

        public void DrawRectangles(Pen pen, RectangleF[] rects)
        {
            foreach (RectangleF currentRectangle in rects)
                this.DrawRectangle(pen, currentRectangle);
        }

        public void DrawRectangles(Pen pen, Rectangle[] rects)
        {
            foreach (Rectangle currentRectangle in rects)
                this.DrawRectangle(pen, currentRectangle);
        }

        private SizeF messuareRectangle(string s, Font f)
        {
            Bitmap testBmp = new Bitmap(1000, 1000);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(testBmp);

            SizeF currentSize = g.MeasureString(s, f);
            testBmp.Dispose();
            testBmp = null;
            return currentSize;
        }

        public void DrawString(string s, Font font, Brush brush, PointF point)
        {
            RectangleF currentRectangle = new RectangleF(point, this.messuareRectangle(s, font));
            this.DrawString(s, font, brush, currentRectangle);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle)
        {
            this.DrawString(s, font, brush, layoutRectangle, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
        }

        public void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format)
        {
            RectangleF currentRectangle = new RectangleF(point, this.messuareRectangle(s, font));
            this.DrawString(s, font, brush, currentRectangle, format);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
        {
            SlimDX.DirectWrite.TextFormat textFormat;

            SlimDX.DirectWrite.FontStyle fStlye = SlimDX.DirectWrite.FontStyle.Normal;
            switch (font.Style)
            {
                case FontStyle.Bold: fStlye = SlimDX.DirectWrite.FontStyle.Oblique; break;
                case FontStyle.Italic: fStlye = SlimDX.DirectWrite.FontStyle.Italic; break;
            }

            textFormat = m.CreateTextFormat(font.FontFamily.Name, SlimDX.DirectWrite.FontWeight.Regular, fStlye, SlimDX.DirectWrite.FontStretch.Expanded, font.Size, "de-de");

            switch (format.Alignment)
            {
                case StringAlignment.Center: textFormat.TextAlignment = SlimDX.DirectWrite.TextAlignment.Center; break;
                case StringAlignment.Near: textFormat.TextAlignment = SlimDX.DirectWrite.TextAlignment.Leading; break;
                case StringAlignment.Far: textFormat.TextAlignment = SlimDX.DirectWrite.TextAlignment.Trailing; break;
            }

            switch (format.LineAlignment)
            {
                case StringAlignment.Center: textFormat.ParagraphAlignment = SlimDX.DirectWrite.ParagraphAlignment.Center; break;
                case StringAlignment.Near: textFormat.ParagraphAlignment = SlimDX.DirectWrite.ParagraphAlignment.Near; break;
                case StringAlignment.Far: textFormat.ParagraphAlignment = SlimDX.DirectWrite.ParagraphAlignment.Far; break;
            }

            this.renderTarget.DrawText(s, textFormat, layoutRectangle, new SlimDX.Direct2D.SolidColorBrush(renderTarget, new SlimDX.Color4((new Pen(brush)).Color)));
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y)
        {
            this.DrawString(s, font, brush, new PointF(x, y));
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format)
        {
            this.DrawString(s, font, brush, new PointF(x, y), format);
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        public void FillClosedCurve(Brush brush, PointF[] points)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        public void FillClosedCurve(Brush brush, Point[] points)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        /// <param name="fillmode"></param>
        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        /// <param name="fillmode"></param>
        public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        /// <param name="fillmode"></param>
        /// <param name="tension"></param>
        public void FillClosedCurve(Brush brush, Point[] points, FillMode fillmode, float tension)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        /// <param name="fillmode"></param>
        /// <param name="tension"></param>
        public void FillClosedCurve(Brush brush, PointF[] points, FillMode fillmode, float tension)
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(Brush brush, RectangleF rect)
        {
            this.renderTarget.FillEllipse(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(new Pen(brush).Color)), new SlimDX.Direct2D.Ellipse() { Center = new PointF(rect.Width / 2F, rect.Height / 2F), RadiusX = rect.Width / 2F, RadiusY = rect.Height / 2F });
        }

        public void FillEllipse(Brush brush, Rectangle rect)
        {
            this.FillEllipse(brush, new RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height));
        }

        public void FillEllipse(Brush brush, int x, int y, int width, int height)
        {
            this.FillEllipse(brush, new Rectangle(x, y, width, height));
        }

        public void FillEllipse(Brush brush, float x, float y, float width, float height)
        {
            this.FillEllipse(brush, new RectangleF(x, y, width, height));
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="path"></param>
        public void FillPath(Brush brush, GraphicsPath path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="rect"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void FillPie(Brush brush, Rectangle rect, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void FillPie(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public void FillPie(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        public void FillPolygon(Brush brush, Point[] points)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        /// <param name="fillMode"></param>
        public void FillPolygon(Brush brush, PointF[] points, FillMode fillMode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="points"></param>
        /// <param name="fillMode"></param>
        public void FillPolygon(Brush brush, Point[] points, FillMode fillMode)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(Brush brush, RectangleF rect)
        {
            this.renderTarget.FillRectangle(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(new Pen(brush).Color)), rect);
        }

        public void FillRectangle(Brush brush, Rectangle rect)
        {
            this.renderTarget.FillRectangle(new SlimDX.Direct2D.SolidColorBrush(this.renderTarget, new SlimDX.Color4(new Pen(brush).Color)), rect);
        }

        public void FillRectangle(Brush brush, int x, int y, int width, int height)
        {
            this.FillRectangle(brush, new Rectangle(x, y, width, height));
        }

        public void FillRectangle(Brush brush, float x, float y, float width, float height)
        {
            this.FillRectangle(brush, new RectangleF(x, y, width, height));
        }

        public void FillRectangles(Brush brush, Rectangle[] rects)
        {
            foreach (Rectangle rect in rects)
                this.FillRectangle(brush, rect);
        }

        public void FillRectangles(Brush brush, RectangleF[] rects)
        {
            foreach (RectangleF rect in rects)
                this.FillRectangle(brush, rect);
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="region"></param>
        public void FillRegion(Brush brush, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
