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
    /// Window3.xaml 的互動邏輯
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        int have=100,num,type,type_c;
        string player, com,x;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            num = integerupdown.Value.Value;
            if (num <= 0 || num > have)
            {
                MessageBox.Show("下注金額不得小於0\n或下注金額不得大於剩餘賭金");
                return;
            }
            type = 0;//剪刀
            math();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            num = integerupdown.Value.Value;
            if (num <= 0 || num > have)
            {
                MessageBox.Show("下注金額不得小於0\n或下注金額不得大於剩餘賭金");
                return;
            }
            type = 1;//石頭
            math();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            num = integerupdown.Value.Value;
            if (num <= 0 || num > have)
            {
                MessageBox.Show("下注金額不得小於0\n或下注金額不得大於剩餘賭金");
                return;
            }
            type = 2;//布
            math();
        }

        private void math()
        {
            var rand = new Random();
            type_c = rand.Next(3);
            if(type == 0)//剪刀
            {
                player = "剪刀";
                if (type_c == 0)
                { //剪刀
                    com = "剪刀";
                    textbox.Background = new SolidColorBrush(Colors.LightGray);//平手
                    x = "平手";
                }
                if (type_c == 1)
                { //石頭
                    com = "石頭";
                    textbox.Background = new SolidColorBrush(Colors.LightPink);//電腦贏
                    have = have - num;
                    x = "電腦贏";
                }
                if (type_c == 2)
                { //布
                    com = "布";
                    textbox.Background = new SolidColorBrush(Colors.LightGreen);//玩家贏
                    have = have + num;
                    x = "玩家贏";
                }
            }
            if (type == 1)//石頭
            {
                player = "石頭";
                if (type_c == 0)
                { //剪刀
                    com = "剪刀";
                    textbox.Background = new SolidColorBrush(Colors.LightGreen);//玩家贏
                    have = have + num;
                    x = "玩家贏";
                }
                if (type_c == 1)
                { //石頭
                    com = "石頭";
                    textbox.Background = new SolidColorBrush(Colors.LightGray);//平手
                    x = "平手";
                }
                if (type_c == 2)
                { //布
                    com = "布";
                    textbox.Background = new SolidColorBrush(Colors.LightPink);//電腦贏
                    have = have - num;
                    x = "電腦贏";
                }
            }
            if (type == 2)//布
            {
                player = "布";
                if (type_c == 0)
                { //剪刀
                    com = "剪刀";
                    textbox.Background = new SolidColorBrush(Colors.LightPink);//電腦贏
                    have = have - num;
                    x = "電腦贏";
                }
                if (type_c == 1)
                { //石頭
                    com = "石頭";
                    textbox.Background = new SolidColorBrush(Colors.LightGreen);//玩家贏
                    have = have + num;
                    x = "玩家贏";
                }
                if (type_c == 2)
                { //布
                    com = "布";
                    textbox.Background = new SolidColorBrush(Colors.LightGray);//平手  
                    x = "平手";
                }
            }
            textbox.Text = $"玩家出{player}，電腦出{com}，{x}。\n此次下注{num}元，賭金剩餘{have}";
        }

    }
}
