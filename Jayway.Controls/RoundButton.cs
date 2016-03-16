using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jayway.Controls
{
    public class RoundButton : Button
    {
        private object _layoutRoot; 
		public static readonly DependencyProperty ImageProperty  = DependencyProperty.Register("Image", typeof(ImageSource), typeof(RoundButton), null); 

        public RoundButton() : base()
        {
            DefaultStyleKey = typeof(RoundButton);
        }
		

		[Description("The image displayed by the button in dark theme (and in normal mode)"), Category("Common Properties")]
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
         }

        public override void OnApplyTemplate()
        {
            _layoutRoot = GetTemplateChild( "LayoutRoot" ) as Border;
            Debug.Assert( _layoutRoot != null, "LayoutRoot is null" );
            base.OnApplyTemplate();
        }
    }
}
