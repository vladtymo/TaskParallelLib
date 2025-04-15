using PropertyChanged;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05_async_await_ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel vm = new();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = await HardWorkAsync();
            MessageBox.Show($"Count: {count}");
        }

        public Task<int> HardWorkAsync()
        {
            return Task.Run(() =>
            {
                int count = 0;
                while (vm.Progress < 100)
                {
                    vm.Progress++;
                    Thread.Sleep(50);
                    ++count;
                }
                return count;
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.Progress = 0;
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public int Progress { get; set; } = 10;
    }
}