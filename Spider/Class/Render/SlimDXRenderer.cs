using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using D2D = SlimDX.Direct2D;
using System.Drawing.Imaging;
using SlimDX;
using SlimDX.DirectWrite;
using System.Drawing.Drawing2D;
using Spider.Class.Render.Graphics;

namespace Spider.Class.Render
{
    public class SlimDXRenderer : Renderer
    {
        // For drawing with slimDX
        private D2D.Factory factory;
        private D2D.WindowRenderTarget renderTarget;
        private D2D.LinearGradientBrush backBrushEx;
        private D2D.GradientStopCollection backBrushGradient;
        private TextFormat textFormatCentered;
        private List<Bitmap> gr = new List<Bitmap>();
        private List<D2D.Bitmap> gb = new List<D2D.Bitmap>();
        private Image backgroundImg;
        private Graphics.DirectGraphics e = null;

        new public Image BackgroundImage
        {
            get { return backgroundImg; }
            set
            {
                backgroundImg = value;
                this.OnDraw();
            }
        }        

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            if (this.FinishedInit)
            {
                this.renderTarget.Resize(this.Size);
                this.backBrushEx.StartPoint = new PointF(0, this.Height);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.FinishedInit)
            {
                this.renderTarget.Resize(this.Size);
                this.backBrushEx.StartPoint = new PointF(0, this.Height);
            }
        }

        private void initializeGraphics()
        {
            factory = new D2D.Factory(D2D.FactoryType.SingleThreaded, D2D.DebugLevel.None);

            //Create the render target
            renderTarget = new D2D.WindowRenderTarget(factory, new D2D.WindowRenderTargetProperties()
            {
                Handle = this.Handle,
                PixelSize = this.Size,
                PresentOptions = D2D.PresentOptions.Immediately
            });

            //Create linear gradient brush
            D2D.GradientStop[] gradientStops = new D2D.GradientStop[]
            {
               new D2D.GradientStop(){ Position = 0f, Color = new Color4(Color.White) },
                new D2D.GradientStop(){ Position = 1f, Color = new Color4(Color.White) }
            };
            backBrushGradient = new D2D.GradientStopCollection(renderTarget, gradientStops);
            backBrushEx = new D2D.LinearGradientBrush(renderTarget, backBrushGradient, new D2D.LinearGradientBrushProperties() { StartPoint = new PointF(0, this.Height), EndPoint = new PointF(0, 0) });

            //Update initialization flag
            this.FinishedInit = true;
        }

        public override void BeforePaint(IGraphics e)
        {
            this.DoOnPaint(this.e);
        }

        public override void DoOnPaint(Render.Graphics.IGraphics e)
        {
            if (this.renderTarget.Size.Height != this.Size.Height || this.renderTarget.Size.Width != this.Size.Width)
                this.renderTarget.Resize(this.Size);
            this.renderTarget.BeginDraw();

            try
            {
                this.renderTarget.Clear(new Color4(this.BackColor));
                e.DrawImage(this.BackgroundImage, this.DisplayRectangle);
                base.DoOnPaint(this.e);
            }
            finally
            {
                this.renderTarget.EndDraw();
            }
        }

        public override void OnInit(Game currentGame, Form owner, Save settings)
        {
            base.currentGame = currentGame;
            base.owner = owner;
            base.info = settings;

            this.owner.Controls.Add(this);
            this.Dock = DockStyle.Fill;

            try
            {
                SlimDX.DirectWrite.Factory m = new SlimDX.DirectWrite.Factory(FactoryType.Shared);
                textFormatCentered = m.CreateTextFormat(this.Font.FontFamily.Name, SlimDX.DirectWrite.FontWeight.Regular, SlimDX.DirectWrite.FontStyle.Normal, SlimDX.DirectWrite.FontStretch.Expanded, 50, "de-de");
                textFormatCentered.TextAlignment = SlimDX.DirectWrite.TextAlignment.Center;
                textFormatCentered.ParagraphAlignment = SlimDX.DirectWrite.ParagraphAlignment.Center;
            }
            catch (Exception)
            { }

            this.initializeGraphics();

            this.FinishedInit = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            try
            {
                if (string.IsNullOrEmpty(settings.Background))
                    this.BackgroundImage = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "Image.jpg"));
                else
                    this.BackgroundImage = Image.FromFile(settings.Background);
            }
            catch (Exception)
            { }

            this.e = new Graphics.DirectGraphics(this.renderTarget);
            this.Invalidate();
        }

        public override void OnDestroy()
        {
            this.e.Clear();
        }
    }
}
