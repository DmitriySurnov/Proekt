using System.IO;
using System.Windows;


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
            Title = WinLeng.Title;
            DirectoryInfo di1;
            di1 = new DirectoryInfo("./");
            Info.Path = di1.FullName;
            if (Info.IsNullFile())
                ZagryzGames.IsEnabled = false;
            exit.Content = WinLeng.exit;
            NewGames.Content = WinLeng.NewGames;
            ZagryzGames.Content = WinLeng.ZagryzGames;
            zogolovok.Text = WinLeng.zogolovok;

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