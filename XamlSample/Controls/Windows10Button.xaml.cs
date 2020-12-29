using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    public partial class Windows10Button : UserControl
    {
        public MouseEventHandler OnMouseMove;
        int center = 0;

        public Windows10Button()
        {
            InitializeComponent();
            OnMouseMove += MouseMove;
            center = (int)(ElpEffect.Width / 2);
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            
            var pos = e.GetPosition(this);
            
            Canvas.SetLeft(ElpEffect, pos.X - center);
            Canvas.SetTop(ElpEffect, pos.Y - center);
        }
    }
}
