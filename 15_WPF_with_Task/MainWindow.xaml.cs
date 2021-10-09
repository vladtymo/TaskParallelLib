using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _15_WPF_with_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> items = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            numberList.ItemsSource = items;
        }
        static Task<int> FactorialAsync(int x)
        {
            return Task.Run(() =>
            {
                int result = 1;

                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                    Thread.Sleep(50);
                }

                return result;
            });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            for (int i = 1; i < 10; i++)
            {
                num = await FactorialAsync(i);
                items.Add(num.ToString());
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                string line = "";
                while (!sr.EndOfStream)
                {
                    line = await sr.ReadLineAsync();
                    items.Add(line);
                }
            }
        }
    }
}
