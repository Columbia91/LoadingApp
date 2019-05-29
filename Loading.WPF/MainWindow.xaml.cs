using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Loading.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DoubleAnimation progressBarAnimation = new DoubleAnimation();
            progressBarAnimation.From = progressBar.ActualWidth;
            progressBarAnimation.To = 800;
            progressBarAnimation.Duration = TimeSpan.FromSeconds(2);
            progressBar.BeginAnimation(ProgressBar.WidthProperty, progressBarAnimation);
        }

        private void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int maximum = 100;
            for (int i = 0; i <= maximum; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(50);
            }
            MessageBox.Show("Загрузка завершена");
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
