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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        int num1=0,num2=0,num3=0;
        public Window1()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lb1.Content = ((int)sl1.Value);
            num1 = ((int)sl1.Value);
            sum();
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lb2.Content = ((int)sl2.Value);
            num2 = ((int)sl2.Value);
            sum();
        }

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lb3.Content = ((int)sl3.Value);
            num3 = ((int)sl3.Value);
            sum();
        }

        private void sum()
        {
            double sum = num1*0.3 + num2*0.3 + num3*0.4;

            if(sum < 60)
            {
                textblock1.Background = new SolidColorBrush(Colors.Pink);
            }
            else
            {
                textblock1.Background = new SolidColorBrush(Colors.LightGreen);
            }
            textblock1.Text = $"國文0.3：{num1}\n英文0.3：{num2}\n數學0.4：{num3}\n平均：{sum.ToString("0.0")}";
        }
    }
}
