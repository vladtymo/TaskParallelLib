using System;
using System.IO;
using System.Windows;
using PropertyChanged;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading.Tasks;

namespace _14_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel model = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model;
        }

        private async void GetDirectorySize(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Selected directory is not exists!");
                return;
            }

            try
            {
                //long sum = dir.GetFiles("*", SearchOption.TopDirectoryOnly).Sum(f => f.Length);
                long sum = await GetTotalSize(path);
                MessageBox.Show("Directory Size: " + Utils.BytesToReadableFormat(sum));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Task<long> GetTotalSize(string root)
        {
            return Task.Run(() =>
            {
                long sum = 0;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(root);

                    foreach (var f in dir.GetFiles())
                    {
                        sum += f.Length;
                    }
                    foreach (var d in dir.GetDirectories())
                    {
                        sum += GetTotalSize(d.FullName).Result;
                    }
                    return sum;
                }
                catch
                {
                    return sum;
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    model.SelectedDirPath = dialog.FileName;
                }
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetDirectorySize(model.SelectedDirPath);
            //await HardWorkAsync(100_000);
            MessageBox.Show("Continue...");
        }

        private Task HardWorkAsync(int count)
        {
            return Task.Run(() =>
            {
                int num = 0;
                Random rand = new Random();
                for (int i = 0; i < count; i++)
                {
                    num = rand.Next();
                    App.Current.Dispatcher.Invoke((Action)delegate ()
                    {
                        list.Items.Add(num);
                    });
                    model.Progress = (int)((double)i / count * 100.0);
                }
            });
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public string SelectedDirPath { get; set; }
        public string TotalSize { get; set; }
        public int Progress { get; set; }
    }
}
