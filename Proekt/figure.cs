using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
    public class ImageFigure
    {
        public Image WhiteFigure(int cellSize)
        {
            return Figure(cellSize, @"D:\С# form\22.11.07\Zadanie\WpfApp3\Sprites\w.png");
        }

        private Image Figure(int cellSize,string uri)
        {
            Image ImageFigure = new Image();
            ImageFigure.Width = cellSize - 10;
            ImageFigure.Height = cellSize - 10;
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(uri);
            myBitmapImage.DecodePixelWidth = cellSize - 10;
            myBitmapImage.DecodePixelHeight = cellSize - 10;
            myBitmapImage.EndInit();
            ImageFigure.Source = myBitmapImage;
            return ImageFigure;
        }

        public Image BlackFigure(int cellSize)
        {
            return Figure(cellSize, @"D:\С# form\22.11.07\Zadanie\WpfApp3\Sprites\b.png");
        }
    }


    class figure
    {
        private const int cellSize = 50;
        private ImageFigure Figure = new ImageFigure();
        public Button button;
        public int Index;
        public int Row;
        public int Column;

        public figure(int row, int column, int index)
        {
            Index = index;
            Row = row;
            Column = column;
            button = new Button();
            Background();
            Image();
        }

        public void Image()
        {
            if (Index == 1)
                button.Content = Figure.WhiteFigure(cellSize);
            else if (Index == 2)
                button.Content = Figure.BlackFigure(cellSize);
            else
                button.Content = "";
        }

        public void Background()
        {
            if (Row % 2 == 0)
            {
                if (Column % 2 == 0)
                    button.Background = Brushes.White;
                else
                    button.Background = Brushes.Black;
            }
            else
            {
                if (Column % 2 == 1)
                    button.Background = Brushes.White;
                else
                    button.Background = Brushes.Black;
            }
        }
    }
}
