using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace AccountBook
{
    public class ImageButton:Button
    {
        public static readonly DependencyProperty ImageSourceProperty 
            = DependencyProperty.Register(
                "ImageSource", 
                typeof(ImageSource),
                typeof(ImageButton), 
                null);

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty Image2SourceProperty
            = DependencyProperty.Register(
                "Image2Source",
                typeof(ImageSource),
                typeof(ImageButton),
                null);

        public ImageSource Image2Source
        {
            get { return (ImageSource)GetValue(Image2SourceProperty); }
            set { SetValue(Image2SourceProperty, value); }
        }
    }
}
