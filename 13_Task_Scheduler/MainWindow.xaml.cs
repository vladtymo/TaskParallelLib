﻿using System;
using System.Collections.Generic;
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

namespace _13_Task_Scheduler
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

        private void MakeProgress()
        {
            // invoke the code in the Current thread
            //Application.Current.Dispatcher.Invoke(() =>
            //{
                if (progressBar.Value == progressBar.Maximum)
                    progressBar.Value = progressBar.Minimum;

                while (progressBar.Value < progressBar.Maximum)
                {
                    progressBar.Value++;
                    Thread.Sleep(10);
                }
            //});

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => MakeProgress(), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
