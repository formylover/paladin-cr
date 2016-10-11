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
        private Color m_color1 = Color.LightGreen; // first color
        private Color m_color2 = Color.DarkBlue;  // second color
        private int m_color1Transparent = 64; // transparency degree 
        // (applies to the 1st color)
        private int m_color2Transparent = 64; // transparency degree 
        //  (applies to the 2nd color)

        public Color Color1
        {
            get { return m_color1; }
            set { m_color1 = value; Invalidate(); }
        }

        public Color Color2
        {
            get { return m_color2; }
            set { m_color2 = value; Invalidate(); }
        }

        public int Transparent1
        {
            get { return m_color1Transparent; }
            set { m_color1Transparent = value; Invalidate(); }
        }

        public int Transparent2
        {
            get { return m_color2Transparent; }
            set { m_color2Transparent = value; Invalidate(); }
        }


        public CustomButton()
        {
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
            // Create two semi-transparent colors
            Color c1 = Color.FromArgb
                (m_color1Transparent, m_color1);
            Color c2 = Color.FromArgb
                (m_color2Transparent, m_color2);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }
    }
}
