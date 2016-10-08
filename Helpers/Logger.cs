//!CompilerOption:AddRef:PresentationFramework.dll
//!CompilerOption:AddRef:System.Xaml.dll

using Buddy.Overlay.Notifications;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

using Styx;
using Styx.Common;
using Styx.Helpers;


namespace Paladin.Helpers
{
    internal class Logger
    {
        public static void DiagnosticLog(string message, params object[] args)
        {
            Write(LogLevel.Diagnostic, Colors.MediumPurple, message, args);
        }

        public static void PrintLog(Color color, string message, params object[] args)
        {
            Write(LogLevel.Normal, color, message, args);
        }

        public static void PrintLog(string message, params object[] args)
        {
            Write(LogLevel.Normal, Colors.DodgerBlue, message, args);
        }

        public static void WriteToFileLog(string message, params object[] args)
        {
            Logging.WriteToFileSync(LogLevel.Verbose, "[GGWP] " + message, args);
        }
        
        private static void Write(LogLevel level, Color specificcolor, string message, params object[] args)
        {
            Logging.Write(level, specificcolor, string.Format("[GGWP] {0}", message), args);
        }

        public static void AddToast(string message, Color color)
        {
            StyxWoW.Overlay.AddToast(new ToastLog(() => message, TimeSpan.FromSeconds(4), color, Colors.Black, new FontFamily("Century Gothic"), 25));
        }
    }

    internal class ToastLog : ToastUIComponent
    {
        private TextBlock _textBlock;

        public Color Color
        {
            get; private set;
        }

        public FontFamily FontFamily
        {
            get; private set;
        }

        public Color ShadowColor
        {
            get; private set;
        }

        public uint FontSize
        {
            get; private set;
        }

        public override FrameworkElement GuiElement
        {
            get { return TextBlock; }
        }

        private TextBlock TextBlock
        {
            get
            {
                var textBlock0 = _textBlock;
                if (textBlock0 != null) return textBlock0;
                var textBlock = Updater();
                var textBlock1 = textBlock;
                _textBlock = textBlock;
                textBlock0 = textBlock1;
                return textBlock0;
            }
        }

        public Func<string> TextProducer { get; private set; }

        public ToastLog(Func<string> textProducer, TimeSpan duration, Color color, Color shadowColor, FontFamily fontFamily, uint fontSize)
        {
            TextProducer = textProducer;
            DisplayDuration = duration;
            Color = color;
            ShadowColor = shadowColor;
            FontFamily = fontFamily;
            FontSize = fontSize;

        }

        private TextBlock Updater()
        {
            var textBlock = new TextBlock
            {
                Text = TextProducer(),
                FontFamily = FontFamily,
                FontSize = FontSize,
                FontWeight = FontWeights.UltraBold,
                Foreground = new SolidColorBrush(Color),
                RenderTransformOrigin = new Point(0.5, 0.5),
                IsHitTestVisible = false,
                TextAlignment = TextAlignment.Center
            };

            var dropShadowEffect = new DropShadowEffect
            {
                Color = ShadowColor,
                BlurRadius = 25,
                ShadowDepth = 0
            };

            textBlock.Effect = dropShadowEffect;
            textBlock.RenderTransform = new ScaleTransform(1, 1);
            var textBlock1 = textBlock;
            var scaleTransform = new ScaleTransform(1, 1);
            textBlock1.RenderTransform = scaleTransform;

            return textBlock1;
        }

        protected override void Update()
        {
            TextBlock.Text = TextProducer();
        }
    }
}
