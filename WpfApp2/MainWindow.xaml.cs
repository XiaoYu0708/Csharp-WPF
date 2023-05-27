using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Drink> drinks = new List<Drink>();
        List<OrderItems> order = new List<OrderItems>();
        public MainWindow()
        {
            InitializeComponent();

            AddNewDrink(drinks);
            
            DisplayDrinks(drinks);
        }

        private void DisplayDrinks(List<Drink> drinks)
        {
            foreach (Drink d in drinks)
            {
                StackPanel sp = new StackPanel();
                CheckBox cb = new CheckBox();
                //TextBox tb = new TextBox();
                Slider sl = new Slider();
                Label lb = new Label();
                sp.Orientation = Orientation.Horizontal;

                cb.Content = d.Name + d.Size + d.Price;
                cb.Margin = new Thickness(5);
                cb.Width = 150;
                cb.Height = 25;

                sl.Value = 0;
                sl.Width = 100;
                sl.Minimum = 0;
                sl.Maximum = 15;
                sl.TickPlacement = TickPlacement.BottomRight;
                sl.TickFrequency = 1;
                sl.IsSnapToTickEnabled = true;

                lb.Width = 50;

                //tb.Width = 80;
                //tb.Height = 25;
                //tb.TextAlignment = TextAlignment.Right;

                Binding myBinding = new Binding("Value");
                myBinding.Source = sl;
                lb.SetBinding(ContentProperty, myBinding);


                sp.Children.Add(cb);
                sp.Children.Add(sl);
                sp.Children.Add(lb);
                stackpanel_DrinkMenu.Children.Add(sp);
            }
        }

        private void AddNewDrink(List<Drink> myDrink)
        {
            //myDrink.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            //myDrink.Add(new Drink() { Name = "咖啡", Size = "小杯", Price = 50 });
            //myDrink.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 30 });
            //myDrink.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 20 });
            //myDrink.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 30 });
            //myDrink.Add(new Drink() { Name = "綠茶", Size = "小杯", Price = 20 });

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "文字檔案|*.text|csv檔案|*.csv|所有檔案|*.*";

            if(dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                StreamReader sr = new StreamReader(path, Encoding.Default);
                CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                
                csv.Read();
                csv.ReadHeader();

                while (csv.Read() == true)
                {
                    Drink d = new Drink() { Name = csv.GetField("Name"), Size = csv.GetField("Size"), Price = csv.GetField<int>("Price") };
                    myDrink.Add(d);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DisplayTextBlock.Text = "";
            PlaceOrder(order);
            DisplayOrderDetail(order);
            savefile(order);
        }

        private void DisplayOrderDetail(List<OrderItems> myOrder)
        {
            int total = 0;
            DisplayTextBlock.Text = "";
            int i = 1;
            String use = "";
            if (rb1.IsChecked == true)
            {
                use = "內用";
            }
            if (rb2.IsChecked == true)
            {
                use = "外帶";
            }
            DisplayTextBlock.Text += $"您所訂購的{use}訂單品項如下：\n";
            foreach (OrderItems items in myOrder)
            {
                total += items.SubTotal;
                Drink drinkItems = drinks[items.Index];
                DisplayTextBlock.Text += $"訂購品項{i}：{drinkItems.Name}{drinkItems.Size}，單價{drinkItems.Price}元 X {items.Quantity}，小記{items.SubTotal}元\n";
                i++;
            }
            if (total != 0)
            {
                DisplayTextBlock.Text += $"\n共{total}元";
                if (total >= 500)
                {
                    DisplayTextBlock.Foreground = Brushes.Red;
                    DisplayTextBlock.FontWeight = FontWeights.Bold;
                    DisplayTextBlock.FontStyle = FontStyles.Normal;
                    DisplayTextBlock.Background = Brushes.White;
                    DisplayTextBlock.Text += $"\n500元以上打8折，本次訂餐金額為{total * 0.8}元";
                }else if (total >= 300)
                {
                    DisplayTextBlock.Foreground = Brushes.Blue;
                    DisplayTextBlock.FontWeight = FontWeights.Normal;
                    DisplayTextBlock.FontStyle = FontStyles.Normal;
                    DisplayTextBlock.Background = Brushes.White;
                    DisplayTextBlock.Text += $"\n300元以上打85折，本次訂餐金額為{total * 0.85}元";
                }else if (total >= 200)
                {
                    DisplayTextBlock.Foreground = Brushes.Green;
                    DisplayTextBlock.FontWeight = FontWeights.Normal;
                    DisplayTextBlock.FontStyle = FontStyles.Italic;
                    DisplayTextBlock.Background = Brushes.White;
                    DisplayTextBlock.Text += $"\n200元以上打9折，本次訂餐金額為{total * 0.9}元";
                }
                else
                {
                    DisplayTextBlock.Foreground = Brushes.White;
                    DisplayTextBlock.FontWeight = FontWeights.Normal;
                    DisplayTextBlock.FontStyle = FontStyles.Normal;
                    DisplayTextBlock.Background = Brushes.Black;
                }

            }               
        }


        private void PlaceOrder(List<OrderItems> myOrder)
        {
            myOrder.Clear();
            for(int i = 0; i < stackpanel_DrinkMenu.Children.Count; i++)
            {
                StackPanel sp = stackpanel_DrinkMenu.Children[i] as StackPanel;
                CheckBox cb = sp.Children[0] as CheckBox;
                Slider sl = sp.Children[1] as Slider;
                int quantity = Convert.ToInt32(sl.Value);

                if(cb.IsChecked == true && quantity != 0)
                {
                    int price = drinks[i].Price;
                    int subtotal = price * quantity;
                    myOrder.Add(new OrderItems() { Index = i, Quantity = quantity, SubTotal = subtotal });

                }
            }
        }

        private void savefile(List<OrderItems> myOrder)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文字檔案(*.txt)|*.txt|所有檔案|*.*";//設定檔案型別
            sf.FileName = "Order_save";//設定預設檔名
            sf.DefaultExt = "txt";//設定預設格式（可以不設）
            sf.AddExtension = true;//設定自動在檔名中新增副檔名
            sf.ShowDialog();
            foreach (OrderItems items in myOrder)
            {
                using (StreamWriter sw = new StreamWriter(sf.FileName))
                {
                    sw.WriteLineAsync(DisplayTextBlock.Text);
                }
            }
        }
    }
}