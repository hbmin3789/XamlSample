using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlSample.Controls
{
    /// <summary>
    /// Windows10Button.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Windows10Button : UserControl, INotifyPropertyChanged,ICommandSource
    {
        #region DependencyProperties

        public static DependencyProperty EffectXProperty =
            DependencyProperty.Register(
                "EffectX",
                typeof(int),
                typeof(Windows10Button),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static DependencyProperty EffectYProperty =
    DependencyProperty.Register(
                "EffectY",
                typeof(int),
                typeof(Windows10Button),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static DependencyProperty EffectSizeProperty =
    DependencyProperty.Register(
                "EffectSize",
                typeof(int),
                typeof(Windows10Button),
                new FrameworkPropertyMetadata(40, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        public MouseEventHandler OnMouseMove;
        int center = 0;


        #region Properties

        private int _effectSize;
        public int EffectSize
        {
            get
            {
                _effectSize = (int)GetValue(EffectSizeProperty);
                return _effectSize;
            }
            set
            {
                SetValue(EffectSizeProperty, value);
                SetProperty(ref _effectSize, value);
            }
        }

        private int _effectX;
        public int EffectX
        {
            get
            {
                _effectX = (int)GetValue(EffectXProperty);
                return _effectX;
            }
            set
            {
                SetValue(EffectXProperty, value);
                SetProperty(ref _effectX, value);
            }
        }

        private int _effectY;
        public int EffectY
        {
            get
            {
                _effectY = (int)GetValue(EffectYProperty);
                return _effectY;
            }
            set
            {
                SetValue(EffectYProperty, value);
                SetProperty(ref _effectY, value);
            }
        }

        public ICommand Command => throw new NotImplementedException();

        public object CommandParameter => throw new NotImplementedException();

        public IInputElement CommandTarget => throw new NotImplementedException();

        #endregion

        public Windows10Button()
        {
            InitializeComponent();
            DataContext = this;
            OnMouseMove += OnMouseMoveEvent;
            center = (int)(EffectSize / 2);
        }

        private void OnMouseMoveEvent(object sender, MouseEventArgs e)
        {

            var pos = e.GetPosition(this);

            EffectX = (int)pos.X - center;
            EffectY = (int)pos.Y - center;
        }

        #region 

        public void SetProperty<T>(ref T container, T value, [CallerMemberName] string callerName = null)
        {
            container = value;
            Notify(callerName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
