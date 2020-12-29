using System.Windows;
using System.Windows.Controls.Primitives;

namespace CustomControls.Controls
{
    public class ValueThumb : Thumb
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int),
            typeof(ValueThumb), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
