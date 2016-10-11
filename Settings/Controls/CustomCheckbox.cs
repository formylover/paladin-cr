using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace Paladin.Settings.Forms.Controls
{
    /// <summary>
    /// Summary description for cuteButton.
    /// </summary>

    public class CustomCheckBox : CheckBox
    {
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = false; }
        }

        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(240, 25); }
        }

        public new Size MaximumSize
        {
            get { return base.Size; }
            set { base.Size = new Size(0, 0); }
        }

        public CustomCheckBox()
        {
            Appearance = System.Windows.Forms.Appearance.Button;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TextAlign = ContentAlignment.MiddleRight;
            FlatAppearance.BorderSize = 0;
            Height = 25;
            ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(BackColor);

            using (SolidBrush brush = new SolidBrush(ForeColor))
                pevent.Graphics.DrawString(Text, Font, brush, 24, 5);

            Point pt = new Point(4, 4);
            Rectangle rect = new Rectangle(pt, new Size(16, 16));

            pevent.Graphics.FillRectangle(Brushes.Beige, rect);
            
            if (Checked)
            {
                using (SolidBrush brush = new SolidBrush(Color.Red))
                using (Font wing = new Font("Wingdings", 16f))
                    pevent.Graphics.DrawString("ü", wing, brush, 1, 2);
            }
            pevent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);
        }
    }
}
