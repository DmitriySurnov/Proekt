using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
    public class countFigure
    {
        private int white;
        private int black;
        
        public countFigure(int White = 12,int Black = 12)
        {
            if (White <= 0 || White > 12)
                White = 12;
            if (Black <= 0 || Black > 12)
                Black = 12;
            white = White;
            black = Black;
        }
        public int White()
        {
            return white;
        }
        public int Black()
        {
            return black;
        }
        public void WhiteMoins()
        {
            white--;
        }
        public void BlackMoins()
        {
            black--;
        }
        public override string ToString()
        {
            return $" {white} {black}";
        }
    }

    public static class Info
    {
        public static string Path = "";
        public static string NameFile = "worker.txt";
        public static bool IsNullFile()
        {
            if (File.Exists(Path + NameFile))
            {
                string[] file = File.ReadAllLines(Path + NameFile);
                if (file.Length != 0)
                    return false;
            }
            return true;
        }
    }

    public class ImageFigure
    {
        public Image WhiteFigure(int cellSize)
        {
            return Figure(cellSize, Info.Path + @"Sprites\w.png");
        }

        public Image WhiteFigureDama(int cellSize)
        {
            return Figure(cellSize, Info.Path + @"Sprites\wD.png");
        }

        private Image Figure(int cellSize, string uri)
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
            return Figure(cellSize, Info.Path + @"Sprites\b.png");
        }

        public Image BlackFigureDama(int cellSize)
        {
            return Figure(cellSize, Info.Path + @"Sprites\bD.png");
        }
    }


    class figure
    {
        private const int cellSize = 50;
        private ImageFigure Figure = new ImageFigure();
        public Button button;
        public bool Dama;
        public int Index;
        public int Row;
        public int Column;

        public figure(int row, int column, int index, bool dama = false)
        {
            Index = index;
            Row = row;
            Column = column;
            Dama = dama;
            button = new Button();
            Background();
            Image();
        }

        public void Image()
        {
            if (Index == 1)
            {
                if (Dama)
                    button.Content = Figure.WhiteFigureDama(cellSize);
                else
                    button.Content = Figure.WhiteFigure(cellSize);
            }
            else if (Index == 2)
            {
                if (Dama)
                    button.Content = Figure.BlackFigureDama(cellSize);
                else
                    button.Content = Figure.BlackFigure(cellSize);
            }
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

        public override string ToString()
        {
            return $"{Row} {Column} {Index} {Dama}";
        }
    }
}
