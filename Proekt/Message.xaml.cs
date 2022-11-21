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
            Title = MessageLeng.Title;
            textBox.Text = MessageLeng.textBox;
            Yes.Content = MessageLeng.Yes;
            No.Content = MessageLeng.No;
            if (i == 0)
                pozdr.Text = MessageLeng.Text_1;
            else if (i == 1)
                pozdr.Text = MessageLeng.Text_2;
            else if (i == 2)
                pozdr.Text = MessageLeng.Text_3;
            else if (i == 4)
                textBox.Text = MessageLeng.Text_4;
            else if (i == 5)
            {
                textBox.Text = MessageLeng.Text_5;
                Width = 1065;
                MinWidth = 1065;
            }
            else if (i == 6)
            {
                textBox.Text = MessageLeng.Text_6;
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
