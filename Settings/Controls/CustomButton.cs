using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace Paladin.Forms.Controls
{
    /// <summary>
    /// Summary description for cuteButton.
    /// </summary>

    public class CustomButton : Button
    {
        public Color Color1
        {
            get { return Color.FromArgb(60, 60, 60); }
        }

        public Color Color2
        {
            get { return Color.FromArgb(40, 40, 40); }
        }

        public int Transparent1
        {
            get { return 170; }
        }

        public int Transparent2
        {
            get { return 100; }
        }

        public CustomButton()
        {
            BackColor = Color.FromArgb(69, 69, 69);
            ForeColor = SystemColors.ActiveCaptionText;
            FlatStyle = FlatStyle.Flat;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
            // Create two semi-transparent colors
            Color c1 = Color.FromArgb(Transparent1, Color1);
            Color c2 = Color.FromArgb(Transparent2, Color2);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }
    }
}
