using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControls.Controls
{
    public class CustomSlider : Slider
    {
        public static readonly DependencyProperty ThumbFillProperty = DependencyProperty.Register("ThumbFill", typeof(SolidColorBrush),
            typeof(CustomSlider), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.LightGray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty TrackBackgroundProperty = DependencyProperty.Register("TrackBackground", typeof(SolidColorBrush),
            typeof(CustomSlider), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty TrackForegroundProperty = DependencyProperty.Register("TrackForeground", typeof(SolidColorBrush),
            typeof(CustomSlider), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty RangeOutsideBrushProperty = DependencyProperty.Register("RangeOutsideBrush", typeof(SolidColorBrush),
                                                                                            typeof(CustomSlider),
                                                                                            new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnRangeOutsideBrushPropertyChanged)));


        public static readonly DependencyProperty RangeInsideBrushProperty = DependencyProperty.Register("RangeInsideBrush", typeof(SolidColorBrush),
                                                                                            typeof(CustomSlider),
                                                                                            new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnRangeInsideBrushPropertyChanged)));

        private static void OnRangeInsideBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        private static void OnRangeOutsideBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public SolidColorBrush RangeOutsideBrush
        {
            get => (SolidColorBrush)GetValue(RangeOutsideBrushProperty);
            set => SetValue(RangeOutsideBrushProperty, value);
        }

        public SolidColorBrush RangeInsideBrush
        {
            get => (SolidColorBrush)GetValue(RangeInsideBrushProperty);
            set => SetValue(RangeInsideBrushProperty, value);
        }

        public SolidColorBrush TrackForeground
        {
            get => (SolidColorBrush)GetValue(TrackForegroundProperty);
            set => SetValue(TrackForegroundProperty, value);
        }


        [Bindable(true)]
        public SolidColorBrush TrackBackground
        {
            get => (SolidColorBrush)GetValue(TrackBackgroundProperty);
            set => SetValue(TrackBackgroundProperty, value);
        }

        [Bindable(true)]
        public SolidColorBrush ThumbFill
        {
            get => (SolidColorBrush)GetValue(ThumbFillProperty);
            set => SetValue(ThumbFillProperty, value);
        }

        public CustomSlider()
        {
            ValueChanged += CustomSlider_ValueChanged;
        }

        private void CustomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Value = e.NewValue;


        }
    }
}
