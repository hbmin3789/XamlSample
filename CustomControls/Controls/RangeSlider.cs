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
    public class RangeSlider : UserControl
    {
        public static readonly DependencyProperty ThumbFillProperty = DependencyProperty.Register("ThumbFill", typeof(Brush),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(
                                                                                                new SolidColorBrush(Colors.Cyan), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                            new PropertyChangedCallback(OnThumbFillPropertyChanged)));

        public static readonly DependencyProperty TrackForegroundProperty = DependencyProperty.Register("TrackForeground", typeof(Brush),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(
                                                                                                new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public static readonly DependencyProperty SmallValueProperty = DependencyProperty.Register("SmallValue", typeof(int),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnSmallValuePropertyChanged)));

        public static readonly DependencyProperty LargeValueProperty = DependencyProperty.Register("LargeValue", typeof(int),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(30, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnLargeValuePropertyChanged)));

        public static readonly DependencyProperty TrackBackgroundProperty = DependencyProperty.Register("TrackBackground", typeof(Brush),
                                                                                            typeof(RangeSlider), new PropertyMetadata(
                                                                                                new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(int),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnMinValueChanged)));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(100, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnMaxValueChanged)));

        public static readonly DependencyProperty RangeSliderModeProperty = DependencyProperty.Register("RangeSliderMode", typeof(ERangeSliderMode),
                                                                                            typeof(RangeSlider),
                                                                                            new FrameworkPropertyMetadata(ERangeSliderMode.Multiple, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                new PropertyChangedCallback(OnRangeSliderModeChanged)));

        private static void OnRangeSliderModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RangeSlider;
            if(control.RangeSliderMode == ERangeSliderMode.Single)
            {
                control.SmallValue = control.MinValue;
                control.LargeValue = control.MaxValue + 1;
            }
            else
            {
                control.SmallValue = control.MinValue;
                control.LargeValue = control.MaxValue;
            }
        }


        private static void OnSmallValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RangeSlider;

            if (control.RangeSliderMode == ERangeSliderMode.Single)
            {
                return;
            }

            if (control.LargeValue <= (int)e.NewValue)
            {
                control.SmallValue = (int)e.OldValue;
                return;
            }         
        }


        private static void OnLargeValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RangeSlider;

            if (control.SmallValue >= (int)e.NewValue)
            {
                control.LargeValue = (int)e.OldValue;
                return;
            }
        }

        private static void OnThumbFillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RangeSlider;
            control.ThumbFill = e.NewValue as Brush;
        }

        public RangeSlider()
        {

        }

        private static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public ERangeSliderMode RangeSliderMode
        {
            get => (ERangeSliderMode)GetValue(RangeSliderModeProperty);
            set => SetValue(RangeSliderModeProperty, value);
        }

        public Brush TrackForeground
        {
            get => (Brush)GetValue(TrackForegroundProperty);
            set => SetValue(TrackForegroundProperty, value);
        }

        public Brush TrackBackground
        {
            get => (Brush)GetValue(TrackBackgroundProperty);
            set => SetValue(TrackBackgroundProperty, value);
        }

        public Brush ThumbFill
        {
            get => (Brush)GetValue(ThumbFillProperty);
            set => SetValue(ThumbFillProperty, value);
        }

        [Bindable(true)]
        public int SmallValue
        {
            get => (int)GetValue(SmallValueProperty);
            set => SetValue(SmallValueProperty, value);
        }

        [Bindable(true)]
        public int LargeValue
        {
            get => (int)GetValue(LargeValueProperty);
            set => SetValue(LargeValueProperty, value);
        }

        public virtual int Value
        {
            get => (int)GetValue(SmallValueProperty);
            set => SetValue(SmallValueProperty, value);
        }

        [Bindable(true)]
        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        [Bindable(true)]
        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }
    }
}
