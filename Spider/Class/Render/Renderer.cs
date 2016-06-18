using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Spider.Class.Structure;
using System.Windows.Forms;
using System.Drawing;

namespace Spider.Class.Render
{
    public abstract class Renderer : Panel
    {
        protected Game currentGame;
        protected Form owner;
        protected Save info;

        public delegate void onMouseDown(MouseEventArgs e);
        new public event onMouseDown MouseDown;

        public virtual Graphics.IGraphics g
        {
            get; set;
        }

        public virtual bool FinishedInit { get; protected set; }

        public virtual void OnDraw()
        {
            if (this.FinishedInit)
                this.Invalidate();
        }

        public virtual void OnInit(Game currentGame, System.Windows.Forms.Form owner, Save settings)
        {
            owner.Controls.Add(this);
            this.Dock = DockStyle.Fill;

            this.currentGame = currentGame;
            this.owner = owner;
            this.info = settings;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
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
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.FinishedInit = true;
        }

        public abstract void OnDestroy();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.MouseDown != null)
                this.MouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = new Graphics.Graphics(e.Graphics);
            this.BeforePaint(g);
        }

        public virtual void BeforePaint(Graphics.IGraphics e)
        {
            this.DoOnPaint(e);
        }

        public virtual void DoOnPaint(Graphics.IGraphics e)
        {
            StringFormat alginment = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
            int i = 0, c = 0;
            foreach (Class.Structure mStr in currentGame.MStructures)
            {
                c = 0;
                int cCard = 0;

                if (mStr.lstCards.Count == 0)
                {
                    // Empty field
                    e.DrawRectangle(new Pen(Color.Violet), new Rectangle(i * (this.info.Distance + this.info.Width), this.info.Y + 10, 100, 150));
                    i++; // Because \/ there will be continued!!!!
                    continue;
                }

                foreach (Class.Cart mCart in mStr.lstCards)
                {
                    int x = i * (this.info.Width + this.info.Distance);
                    int y = this.info.Y + 10 + (c * 10);
                    if (!mCart.Active)
                        e.FillRectangle(new SolidBrush(this.info.ActiveCardsColor), new Rectangle(x, y, this.info.Width, 5));
                    else
                    {
                        Rectangle actCard;
                        if (mStr.lstCards.IndexOf(mCart) == mStr.lstCards.Count - 1)
                            actCard = new Rectangle(i * (this.info.Width + this.info.Distance), y + (cCard * this.info.Distance2), this.info.Width, this.info.Height);
                        else
                            actCard = new Rectangle(i * (this.info.Width + this.info.Distance), y + (cCard * this.info.Distance2), this.info.Width, this.info.Distance2 * 2);

                        e.DrawImageUnscaledAndClipped(mCart.ToImage(), actCard);

                        if (mCart.Selection)
                            e.DrawRectangle(new Pen(this.info.SelectColor, 3), actCard);
                        int fact = 3;
                        if (mCart.IsTipp)
                            e.DrawRectangle(new Pen(this.info.TipColor, 1), new Rectangle(actCard.X + fact, actCard.Y + fact, actCard.Width - fact * 2, actCard.Height - fact * 2));
                        cCard++;
                    }
                    c++;
                }
                i++;
            }

            // Draw winning cards
            for (int f = 1; f <= this.currentGame.WinningCards.Length; f++)
            {
                Rectangle currentRectangle = new Rectangle(this.Width - (this.info.Distance * f) - (this.info.Width * f), this.Height - this.info.Distance - this.info.Height, this.info.Width, this.info.Height);
                if (this.currentGame.WinningCards[f - 1] != null)
                {
                    // Draw card
                    e.DrawImage(this.currentGame.WinningCards[f - 1].ToImage(), currentRectangle);
                }
                else
                {
                    // Draw rectangle
                    e.FillRectangle(Brushes.Green, currentRectangle);
                }
            }

            if (currentGame.EndOfGame)
                e.DrawString("Sie haben gewonnen!", new Font("Segoe UI", 36, FontStyle.Regular), new SolidBrush(this.info.FontColor), this.DisplayRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
    }
}