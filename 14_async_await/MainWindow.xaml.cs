using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PropertyChanged;

namespace _14_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }

        private Task<int> HardWorkAsync(long count)
        {
            return Task.Run(() =>
            {
                int num = 0;
                var random = new Random();
                for (int i = 0; i < count; i++)
                {
                    num = random.Next();
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        list.Items.Add(num);
                    });
                    viewModel.Progress = (int)((double)i / count * 100.0);
                }
                return num;
            });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            long count = 100_000L;

            int result = await HardWorkAsync(count);
            MessageBox.Show($"Done! Result: {result}");
        }


    }

    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public int Progress { get; set; }
    }
}
