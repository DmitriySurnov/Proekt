using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Шашки";
            DirectoryInfo di1;
            di1 = new DirectoryInfo("./");
            Info.Path = di1.FullName;
            if (Info.IsNullFile())
                ZagryzGames.IsEnabled = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewGames_Click(object sender, RoutedEventArgs e)
        {
            var g = new Games();
            g.Show();
            Close();
        }

        private void ZagryzGames_Click(object sender, RoutedEventArgs e)
        {
            var g = new Games(4);
            g.Show();
            Close();
        }
    }
}