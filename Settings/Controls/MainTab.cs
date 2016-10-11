using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Paladin.Settings.Forms.Controls
{
    public partial class MainTab : TabControl
    {
        public MainTab()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;

            // Changes tab size, the selection triangle needs to be readjusted if this changes
            ItemSize = new Size(35, 110);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
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
                SelectedTab.Padding = new Padding(10, 10, 10, 10);
                SelectedTab.Margin = new Padding(3, 3, 3, 3);
                SelectedTab.BackColor = Color.FromArgb(64, 64, 64);
            }
            catch
            {
            }

            // Transparency
            g.Clear(Color.Transparent);

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

            // BACKGROUND COLOR
            //g.Clear(Color.FromArgb(64, 64, 64));

            // Background BEHIND tabs

            var tabbackground = Color.FromArgb(64, 64, 64);

            g.FillRectangle(new SolidBrush(Color.FromArgb(110, tabbackground)), new Rectangle(0, 0, ItemSize.Height + 4, Height));

            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(Width - 1, 0), New Point(Width - 1, Height - 1))    
            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 1, 0), New Point(Width - 1, 0))                   
            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 3, Height - 1), New Point(Width - 1, Height - 1))


            // Line on the right side of the tabs that goes all the way down
            g.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(ItemSize.Height + 3, 0), new Point(ItemSize.Height + 3, 999));
            for (var i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    // This changes the actual tab rectangle
                    var x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    var myBlend = new ColorBlend()
                    {
                        // SELECTED tab color
                        Colors = new Color[3] { Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40) },
                        Positions = new float[3] { 0f, 0.5f, 1f }
                    };

                    var lgBrush = new LinearGradientBrush(x2, Color.Black, Color.Black, 90f);
                    lgBrush.InterpolationColors = myBlend;
                    g.FillRectangle(lgBrush, x2);

                    // Tab border color
                    g.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), x2);

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    Point[] p =
                    {
                        // This is the triangle location, have to add or substract from the Location.Y equally
					    new Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 15),
                        new Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 9),
                        new Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 22)
                    };

                    // Triangle color and OUTLINE color
                    var brush = new SolidBrush(Color.FromArgb(40, 40, 40));

                    g.FillPolygon(brush, p);
                    g.DrawPolygon(new Pen(Color.FromArgb(40, 40, 40)), p);

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
                        catch (Exception ex)
                        {
                            // Font color
                            g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.White, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        // Font color
                        g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.White, x2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }

                    g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Location.X - 1, x2.Location.Y - 1), new Point(x2.Location.X, x2.Location.Y));
                    g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Location.X - 1, x2.Bottom - 1), new Point(x2.Location.X, x2.Bottom));
                }
                else
                {
                    var x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height + 1));
                    g.FillRectangle(new SolidBrush(Color.FromArgb(200, tabbackground)), x2);

                    // Line to the right of the tabs, needs to be changed with the other
                    g.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(x2.Right, x2.Top), new Point(x2.Right, x2.Bottom));

                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                g.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(x2.Location.X + 8, x2.Location.Y + 6));
                                g.DrawString("      " + TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            // Unselected font color
                            g.DrawString(TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        // Unselected font color
                        g.DrawString(TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }


                }
            }

            g.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(0, Height - 1), new Point(800, Height - 1));

            // Topmost line
            g.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(0, 0), new Point(800, 0));

            // Left line
            g.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(0, 0), new Point(0, Height - 1));

            // Right Line
            g.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(Width - 1, 0), new Point(Width - 1, Height - 1));

            e.Graphics.DrawImage((Image)b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
        }
    }
}