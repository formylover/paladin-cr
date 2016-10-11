using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paladin.Settings.Forms.Controls
{
    public partial class TopTab : TabControl
    {
        public TopTab()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;

            // Changes tab size, the selection triangle needs to be readjusted if this changes
            ItemSize = new Size(125, 30);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var b = new Bitmap(Width, Height);

            var g = Graphics.FromImage(b);

            try
            {
                SelectedTab.BackColor = Color.FromArgb(64, 64, 64);
            }
            catch
            {
            }

            // Transparency
            g.Clear(Color.FromArgb(69, 69, 69));
            if ((this.Parent != null))
            {
                var clipRect = new Rectangle();

                clipRect.Offset(this.Location);
                var state = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }
                finally
                {
                    g.Restore(state);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                }
            }

            // Background behind tabs
            //g.FillRectangle(new SolidBrush(Color.Pink), new Rectangle(0, 0, ItemSize.Height + 4, Height));

            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(Width - 1, 0), New Point(Width - 1, Height - 1))    
            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 1, 0), New Point(Width - 1, 0))                   
            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 3, Height - 1), New Point(Width - 1, Height - 1))


            //g.DrawLine(new Pen(Color.FromArgb(205, 142, 153)), new Point(ItemSize.Height + 3, 0), new Point(ItemSize.Height + 3, 999));
            for (var i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    // This changes the actual tab rectangle
                    var x2 = new Rectangle(new Point(GetTabRect(i).Location.X, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                    var myBlend = new ColorBlend()
                    {
                        Colors = new Color[3] { Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40) },
                        Positions = new float[3] { 0f, 0.5f, 1f }
                    };

                    var lgBrush = new LinearGradientBrush(x2, Color.Black, Color.Black, 90f);
                    lgBrush.InterpolationColors = myBlend;
                    g.FillRectangle(lgBrush, x2);

                    // Tab border color
                    //g.DrawRectangle(new Pen(Color.FromArgb(205, 142, 153)), x2);


                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                g.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X + 8, x2.Location.Y + 6));
                                g.DrawString("      " + TabPages[i].Text, Font, Brushes.White, x2, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception)
                        {
                            g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.White, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.White, x2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }

                    // These are commented cause they look like a glitch on spell tab
                    //g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Location.X - 1, x2.Location.Y - 1), new Point(x2.Location.X, x2.Location.Y));
                    //g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Location.X - 1, x2.Bottom - 1), new Point(x2.Location.X, x2.Bottom));
                }
                else
                {
                    var x2 = new Rectangle(new Point(GetTabRect(i).Location.X, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height));

                    // This is INACTIVE tab background color
                    //g.FillRectangle(new SolidBrush(Color.Pink), x2);


                    // Line to the right of the tabs, needs to be changed with the other
                    //g.DrawLine(new Pen(Color.FromArgb(205, 142, 153)), new Point(x2.Right, x2.Top), new Point(x2.Right, x2.Bottom));

                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                g.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X, x2.Location.Y));
                                g.DrawString("      " + TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception)
                        {
                            g.DrawString(TabPages[i].Text, Font, Brushes.White, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        g.DrawString(TabPages[i].Text, Font, Brushes.White, x2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                }
            }

            //g.DrawLine(new Pen(Color.FromArgb(205, 142, 153)), new Point(0, Height - 1), new Point(800, Height - 1));

            // Topmost gray line
            //g.DrawLine(new Pen(Color.FromArgb(205, 142, 153)), new Point(0, 0), new Point(800, 0));

            // Rectangle under menu
            g.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, 31, Width, 3);
            g.DrawLine(new Pen(Color.FromArgb(35, 35, 35)), new Point(0, 33), new Point(Width, 33));


            // Left line
            // g.DrawLine(new Pen(Color.FromArgb(205, 142, 153)), new Point(0, 0), new Point(0, Height - 1));

            // Right Line
            //g.DrawLine(new Pen(Color.FromArgb(205, 142, 153)), new Point(Width - 1, 0), new Point(Width - 1, Height - 1));

            e.Graphics.DrawImage((Image)b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
        }
    }
}