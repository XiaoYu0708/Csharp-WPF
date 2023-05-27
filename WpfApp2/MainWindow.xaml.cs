using System;
using System.Collections.Generic;
using System.Drawing;
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
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int sizeoftext = textbox1.Text.Length;
            string[] primes = new string[textbox1.Text.Length];
            string[] items = new string[100];
            int[] num = new int[100];
            string s = textbox1.Text;
            char[] separators = new char[] { ' ', '.', ',' };
            string[] text = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            textblock2.Text = "";
            int f = 0;
            foreach (var n in text)
            {
                primes[f] = n;
                f++;
            }
            int k = 0;
            foreach
(var n in primes)

            {
                int index = Array.IndexOf(items, n);
                if (index >
               -1)

                {
                    var x = Array.FindIndex(items, x => x == n);
                    num[x]++;

                }
                else

                {
                    items[k] = n;
                    k++;

                }

            }
            int y = 0;
            foreach
           (var n in num)

            {
                num[y]++;
                y++;

            }
            y = 0;
            for
           (int i = 0; i < k; i++)

            {
                textblock2.Text += $"{items[y]}:{num[y]}\n";
                y++;

            }

        }

    }
}