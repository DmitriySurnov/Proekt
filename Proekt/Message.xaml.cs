using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
        }

        public Message(int i)
        {
            InitializeComponent();
            if (i == 0)
                pozdr.Text = "поздравляем победитель игрок 1";
            else if (i == 1)
                pozdr.Text = "поздравляем победитель игрок 2";
            else if (i == 2)
                pozdr.Text = "поздравляем ничья";
            else if (i == 4)
                textBox.Text = "Согласны на ничью? ";
            else if (i == 5)
            {
                textBox.Text = "Вы уверины что хотите начать новую игру? ";
                Width = 1065;
                MinWidth = 1065;
            }
            else if (i == 6)
            {
                textBox.Text = "Вы уверины что хотите загрузить игру? ";
                Width = 1065;
                MinWidth = 1065;
            }
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
