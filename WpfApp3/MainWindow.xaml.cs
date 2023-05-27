using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Dictionary<string, int> foods = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
            AddNewFood(foods);
        }
        private void AddNewFood(Dictionary<string, int> myFood)
        {
            myFood.Add("大麥克漢堡(套餐)", 150);
            myFood.Add("大麥克漢堡(單點)", 90);
            myFood.Add("麥香雞漢堡(套餐)", 140);
            myFood.Add("麥香雞漢堡(單點)", 80);
            myFood.Add("雙層牛肉堡(套餐)", 160);
            myFood.Add("雙層牛肉堡(單點)", 100);
        }
        private void PlaceOrder(object sender, TextChangedEventArgs e)
        {
            var targetTextbox = sender as TextBox;
            bool success = int.TryParse(targetTextbox.Text, out int count);
            if (!success) MessageBox.Show("請輸入整數", "輸入錯誤");
            else if (count <= 0) MessageBox.Show("請輸入正整數", "輸入錯誤");
            else
            {
                StackPanel targetStackPanel = targetTextbox.Parent as StackPanel;
                Label targetLabel = targetStackPanel.Children[0] as Label;
                string foodItem = targetLabel.Content.ToString();
                int itemPrice = foods[foodItem];
            }
        }
        double num = 0.0;
        int output;
        int xoutput;
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] tbs = { textbox1, textbox2, textbox3, textbox4, textbox5, textbox6 };
            int total = 0;
            double xnum = 0;
            order.Text = "";
            for (int i = 0; i < tbs.Length; i++)
            {
                bool success = int.TryParse(tbs[i].Text, out int count);
                if (count > 0)
                {
                    StackPanel targetStackPanel = tbs[i].Parent as StackPanel;
                    Label targetLabel = targetStackPanel.Children[0] as Label;
                    string foodItem = targetLabel.Content.ToString();
                    int itemPrice = foods[foodItem];
                    order.Text += $"{foodItem} 點了{count}份\n";
                    total = total + (itemPrice * count);
                    xnum = total * 0.1;
                    xoutput = (int)Math.Round(xnum);
                    num = num + xnum;
                    output = (int)Math.Round(num);
                }
            }
            order.Text += $"\n你點的餐點總價為:{total}\n";
            if (total >= 500 && total < 1000)
                order.Text += $"折扣後的總價錢為:{total * 0.9}(滿500打9折)\n";
            else if (total > 1000)
                order.Text += $"折扣後的總價錢為:{total * 0.85}(滿1000打85折)\n";
            order.Text += $"\n這次餐點為你儲到的點數為: {xoutput} 點\n";
            order.Text += $"\n你現在的總點數為{output}點";
        }
    }
}