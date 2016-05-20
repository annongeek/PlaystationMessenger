using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Playstation_Friends_List
{
    public class MarqueeControl : Label
    {
        private Queue<MarqueeMessage> adding;
        private int bounceCount = 0;
        private IContainer components = null;
        private int distanceFromEdge = 10;
        private int distanceToMove = 1;
        private int interval = 20;
        private Color linkColor = Color.Blue;
        private Font linkFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline | FontStyle.Bold);
        private bool mouseEnter = false;
        private List<MarqueeMessage> moving;
        private System.Windows.Forms.Orientation orientation = System.Windows.Forms.Orientation.Horizontal;
        private int tickerInterval = 0xbb8;
        private Timer tmrHold;
        private Timer tmrMove;
        private Timer tmrVerticalMove;

        public event LinkClickedHandler LinkClicked;

        public MarqueeControl()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            moving = new List<MarqueeMessage>();
            adding = new Queue<MarqueeMessage>();
        }

        public void AddMessage(MarqueeMessage m)
        {
            m.Parent = this;
            m.MeasureLinkTextSize();
            m.MeasureTextSize();
            if (orientation == System.Windows.Forms.Orientation.Horizontal)
            {
                m.Left = base.Width;
            }
            else
            {
                m.Left = 1;
                m.Top = Height;
            }
            if (moving.Count > 0)
            {
                adding.Enqueue(m);
            }
            else
            {
                if (orientation == System.Windows.Forms.Orientation.Vertical)
                {
                    tmrVerticalMove.Start();
                    tmrHold.Stop();
                }
                moving.Add(m);
            }
        }

        public void AddMessage(string Text)
        {
            MarqueeMessage m = new MarqueeMessage
            {
                Text = Text
            };
            AddMessage(m);
        }

        public void AddMessage(string Text, Image img)
        {
            MarqueeMessage m = new MarqueeMessage
            {
                Text = Text,
                Image = img
            };
            AddMessage(m);
        }

        public void AddMessage(string Text, string LinkText, object link)
        {
            MarqueeMessage m = new MarqueeMessage
            {
                Text = Text,
                LinkText = LinkText,
                Link = link
            };
            AddMessage(m);
        }

        public void AddMessage(string Text, string LinkText, object link, Image img)
        {
            MarqueeMessage m = new MarqueeMessage
            {
                Text = Text,
                LinkText = LinkText,
                Link = link,
                Image = img
            };
            AddMessage(m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            tmrMove = new Timer(components);
            tmrVerticalMove = new Timer(components);
            tmrHold = new Timer(components);
            base.SuspendLayout();
            tmrMove.Enabled = true;
            tmrMove.Tick += new EventHandler(tmrMove_Tick);
            tmrVerticalMove.Tick += new EventHandler(tmrVerticalMove_Tick);
            tmrHold.Interval = 0xbb8;
            tmrHold.Tick += new EventHandler(tmrHold_Tick);
            base.ResumeLayout(false);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            foreach (MarqueeMessage message in moving)
            {
                int x = message.Left + 2;
                if (message.Image != null)
                {
                    x += 0x11;
                }
                if (!string.IsNullOrEmpty(message.Text))
                {
                    x += message.TextSize.Width;
                }
                Rectangle rectangle = new Rectangle(x, 1, message.LinkTextSize.Width, Height);
                if (rectangle.Contains(e.Location))
                {
                    if (LinkClicked != null)
                    {
                        LinkClicked(message, message.LinkText, message.Link);
                    }
                    return;
                }
                if (rectangle.Contains(e.Location))
                {
                    Cursor = Cursors.Hand;
                    return;
                }
            }
            Cursor = Cursors.Default;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mouseEnter = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouseEnter = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            foreach (MarqueeMessage message in moving)
            {
                int x = message.Left + 2;
                if (message.Image != null)
                {
                    x += 0x11;
                }
                if (!string.IsNullOrEmpty(message.Text))
                {
                    x += message.TextSize.Width;
                }
                Rectangle rectangle = new Rectangle(x, 1, message.LinkTextSize.Width, Height);
                if (rectangle.Contains(e.Location))
                {
                    Cursor = Cursors.Hand;
                    return;
                }
            }
            Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.FromKnownColor(KnownColor.Control));
            foreach (MarqueeMessage message in moving)
            {
                int num;
                if (orientation == System.Windows.Forms.Orientation.Horizontal)
                {
                    num = message.Left + 2;
                    if (message.Image != null)
                    {
                        e.Graphics.DrawImage(message.Image, message.Left + 1, message.Top + 2, 0x10, 0x10);
                        num += 0x11;
                    }
                    if (!string.IsNullOrEmpty(message.Text))
                    {
                        
                      TextRenderer.DrawText(e.Graphics, message.Text, Font, new Point(num, (message.Top + (Height / 2)) - (message.Height / 2)), ForeColor);
                        num += message.TextSize.Width;
                    }
                    if (!string.IsNullOrEmpty(message.LinkText))
                    {
                        TextRenderer.DrawText(e.Graphics, message.LinkText, linkFont, new Point(num, (message.Top + (Height / 2)) - (message.Height / 2)), linkColor);
                        num += message.TextSize.Width;
                    }
                }
                else
                {
                    num = message.Left + 2;
                    if (message.Image != null)
                    {
                        e.Graphics.DrawImage(message.Image, message.Left + 1, message.Top + 2, 0x10, 0x10);
                        num += 0x11;
                    }
                    if (!string.IsNullOrEmpty(message.Text))
                    {
                        TextRenderer.DrawText(e.Graphics, message.Text, Font, new Point(num, (message.Top + (Height / 2)) - (message.Height / 2)), ForeColor);
                        num += message.TextSize.Width;
                    }
                    if (!string.IsNullOrEmpty(message.LinkText))
                    {
                        TextRenderer.DrawText(e.Graphics, message.LinkText, linkFont, new Point(num, (message.Top + (Height / 2)) - (message.Height / 2)), linkColor);
                        num += message.TextSize.Width;
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (MarqueeMessage message in adding)
            {
                message.Left = base.Width;
            }
        }

        private void tmrHold_Tick(object sender, EventArgs e)
        {
            if (!mouseEnter)
            {
                tmrVerticalMove.Start();
                tmrHold.Stop();
            }
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            int num;
            if (mouseEnter || base.DesignMode)
            {
                return;
            }
Label_0025:
            num = 0;
            while (num < moving.Count)
            {
                MarqueeMessage message;
                if (orientation == System.Windows.Forms.Orientation.Horizontal)
                {
                    message = moving[num];
                    if (message == null)
                    {
                        moving.RemoveAt(num);
                        goto Label_0025;
                    }
                    if (((message.Right < (base.Width - distanceFromEdge)) & (adding.Count > 0)) & (num == (moving.Count - 1)))
                    {
                        moving.Add(adding.Dequeue());
                    }
                    if (message.Right > 0)
                    {
                        message.Left -= distanceToMove;
                    }
                    else
                    {
                        moving.RemoveAt(num);
                        num--;
                    }
                }
                else
                {
                    message = moving[0];
                    if (message.Width > base.Width)
                    {
                        if (message.Top == 1)
                        {
                            if ((bounceCount == 0) | (bounceCount == 2))
                            {
                                if (message.Right > base.Width)
                                {
                                    message.Left -= distanceToMove;
                                }
                                else
                                {
                                    bounceCount++;
                                }
                            }
                            else if ((bounceCount == 1) | (bounceCount == 3))
                            {
                                if (message.Left < 1)
                                {
                                    message.Left += distanceToMove;
                                }
                                else
                                {
                                    bounceCount++;
                                }
                            }
                        }
                        if (bounceCount == 4)
                        {
                            tmrVerticalMove.Start();
                            bounceCount = 0;
                        }
                    }
                    else
                    {
                        message.Left = 1;
                        if (message.Top == 1)
                        {
                            tmrHold.Start();
                        }
                    }
                }
                num++;
            }
            base.Invalidate(true);
        }

        private void tmrVerticalMove_Tick(object sender, EventArgs e)
        {
            if (!mouseEnter && (moving.Count != 0))
            {
                MarqueeMessage local1 = moving[0];
                local1.Top--;
                if (moving.Count > 1)
                {
                    MarqueeMessage local2 = moving[1];
                    local2.Top--;
                }
                if (moving[0].Top == 1)
                {
                    tmrVerticalMove.Stop();
                    if (moving[0].Width < base.Width)
                    {
                        tmrHold.Start();
                    }
                }
                if (moving[0].Bottom == 1)
                {
                    tmrHold.Stop();
                    moving.RemoveAt(0);
                    if (adding.Count > 0)
                    {
                        moving.Add(adding.Dequeue());
                        moving[0].Top = Height;
                        moving[0].Left = 1;
                    }
                    else
                    {
                        tmrVerticalMove.Stop();
                    }
                }
                base.Invalidate(true);
            }
        }

        public int DistanceFromEdge
        {
            get
            {
                return distanceFromEdge;
            }
            set
            {
                distanceFromEdge = value;
            }
        }

        public int DistanceToMove
        {
            get
            {
                return distanceToMove;
            }
            set
            {
                distanceToMove = value;
            }
        }

        public int _Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = 0x12;
            }
        }

        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                if (orientation == System.Windows.Forms.Orientation.Vertical)
                {
                    tmrMove.Interval = 40;
                }
                else
                {
                    tmrMove.Interval = value;
                }
            }
        }

        public Color LinkColor
        {
            get
            {
                return linkColor;
            }
            set
            {
                linkColor = value;
            }
        }

        public Font LinkFont
        {
            get
            {
                return linkFont;
            }
            set
            {
                linkFont = value;
            }
        }

        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
                if (value == System.Windows.Forms.Orientation.Vertical)
                {
                    while (moving.Count > 0)
                    {
                        adding.Enqueue(moving[0]);
                        moving.RemoveAt(0);
                    }
                    if (adding.Count > 0)
                    {
                        moving.Add(adding.Dequeue());
                        moving[0].Top = Height;
                        moving[0].Left = 1;
                    }
                    tmrMove.Interval = 30;
                    tmrVerticalMove.Start();
                }
                else
                {
                    tmrMove.Interval = interval;
                }
            }
        }

        public System.Drawing.Size _Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = new System.Drawing.Size(value.Width, 0x12);
            }
        }

        public int TickerInterval
        {
            get
            {
                return tickerInterval;
            }
            set
            {
                tickerInterval = value;
                tmrHold.Interval = value;
            }
        }

        public delegate void LinkClickedHandler(MarqueeMessage message, string linkText, object linkObject);
    }

    public class MarqueeMessage
    {
        private System.Drawing.Image image;
        private int left;
        private object link;
        private string linkText;
        private Size linkTextSize;
        private MarqueeControl parent;
        private string text;
        private Size textSize;
        private int top;

        public void MeasureLinkTextSize()
        {
            if (parent != null)
            {
                linkTextSize = TextRenderer.MeasureText(linkText, parent.LinkFont);
            }
        }

        public void MeasureTextSize()
        {
            if (parent != null)
            {
                textSize = TextRenderer.MeasureText(text, parent.Font);
            }
        }

        public int Bottom
        {
            get
            {
                return (top + 0x10);
            }
        }

        public int Height
        {
            get
            {
                return 0x10;
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                if (image == null)
                {
                    return null;
                }
                try
                {
                    int height = image.Height;
                }
                catch
                {
                    image = null;
                }
                return image;
            }
            set
            {
                image = value;
            }
        }

        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public object Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }

        public string LinkText
        {
            get
            {
                return linkText;
            }
            set
            {
                linkText = value;
                MeasureLinkTextSize();
            }
        }

        public Size LinkTextSize
        {
            get
            {
                return linkTextSize;
            }
            set
            {
                linkTextSize = value;
            }
        }

        internal MarqueeControl Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public int Right
        {
            get
            {
                return (left + Width);
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                MeasureTextSize();
            }
        }

        public Size TextSize
        {
            get
            {
                return textSize;
            }
            set
            {
                textSize = value;
            }
        }

        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        public int Width
        {
            get
            {
                int num = 2;
                if (image != null)
                {
                    num += 0x11;
                }
                if (!string.IsNullOrEmpty(text))
                {
                    num += textSize.Width + 1;
                }
                if (!string.IsNullOrEmpty(linkText))
                {
                    num += linkTextSize.Width;
                }
                return num;
            }
        }
    }
}
