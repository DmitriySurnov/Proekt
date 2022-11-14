using System.Collections.Generic;
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
        const int mapSize = 8;
        const int cellSize = 50;
        figure[,] simpleSteps = new figure[mapSize, mapSize];
        int hod = 1;
        int countWhiteFigure = 12;
        int countBlackFigure = 12;
        bool povtor = false;
        figure b = null;
        List<figure> Meal = null;
        List<figure> lf = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Шашки ходит игрок 1";
            Init();
        }
        public void Init()
        {
            CreateMap();
        }
        public void CreateMap()
        {
            int[,] map = new int[mapSize, mapSize]{
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    simpleSteps[i, j] = new figure(i, j, map[j, i]);
                    grids.Children.Add(simpleSteps[i, j].button);
                    Grid.SetColumn(simpleSteps[i, j].button, i);
                    Grid.SetRow(simpleSteps[i, j].button, j);
                    simpleSteps[i, j].button.Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (b is null)
                foreach (var i in simpleSteps)
                {
                    if ((Button)sender == i.button && i.Index == hod)
                    {
                        i.button.Background = Brushes.Red;
                        b = i;
                        Food_5(i.Row, i.Column);
                        break;
                    }
                }
            else if (b.button == (Button)sender)
            {
                otmena();
                if (povtor)
                    Perevod_hoda();
            }
            else if (((Button)sender).Background == Brushes.Green)
            {
                b.Index = 0;
                b.Image();
                foreach (var i in lf)
                    if ((Button)sender == i.button)
                    {
                        i.Background();
                        i.Index = hod;
                        i.Image();
                        if (!(Meal is null))
                        {
                            foreach (var m in Meal)
                                if ((i.Row + 1 == m.Row || i.Row - 1 == m.Row) &&
                                    (i.Column + 1 == m.Column || i.Column - 1 == m.Column))
                                {
                                    if (m.Index == 1)
                                        countWhiteFigure--;
                                    else
                                        countBlackFigure--;
                                    m.Index = 0;
                                    m.Image();
                                    otmena();
                                    Food_5(i.Row, i.Column);
                                    if (!(Meal is null))
                                    {
                                        povtor = true;
                                        b = i;
                                        b.button.Background = Brushes.Red;
                                        foreach (var s in lf)
                                            if ((i.Row + 1 == s.Row || i.Row - 1 == s.Row) &&
                                            (i.Column + 1 == s.Column || i.Column - 1 == s.Column))
                                                s.Background();
                                        return;
                                    }
                                }
                        }
                        break;
                    }
                otmena();
                Perevod_hoda();
            }
        }

        private void Perevod_hoda()
        {
            if (hod == 1)
            {
                hod = 2;
                Title = "Шашки ходит игрок 2";
            }
            else
            {
                hod = 1;
                Title = "Шашки ходит игрок 1";
            }
            povtor = false;
            if (countBlackFigure == 0)
                Title = "поздравляем победитель игрок 1";
            else if (countWhiteFigure == 0)
                Title = "поздравляем победитель игрок 2";
            else
            {
                if (hod == 1 && countWhiteFigure == 1)
                {
                    foreach (var i in simpleSteps)
                    {
                        if (i.Index == hod)
                        {
                            Food_5(i.Row, i.Column);
                        }
                    }
                }
            }
        }

        private void otmena()
        {
            if (!(b is null))
                b.Background();
            b = null;
            if (!(lf is null))
                foreach (var i in lf)
                    i.Background();
            lf = null;
            Meal = null;
        }
        private void PossibleMove(int i, int j)
        {
            if (simpleSteps[i, j].Index == 0)
            {
                simpleSteps[i, j].button.Background = Brushes.Green;
                if (lf is null)
                    lf = new List<figure>();
                lf.Add(simpleSteps[i, j]);
            }
        }
        private void Food_1(int i, int j)
        {
            if (simpleSteps[i, j].Index == ((hod == 1) ? 2 : 1))
                if (i + 1 < mapSize && j - 1 >= 0)
                {
                    PossibleMove(i + 1, j - 1);
                    if (simpleSteps[i + 1, j - 1].button.Background == Brushes.Green)
                    {
                        if (Meal is null)
                            Meal = new List<figure>();
                        Meal.Add(simpleSteps[i, j]);
                    }
                }
        }
        private void Food_2(int i, int j)
        {
            if (simpleSteps[i, j].Index == ((hod == 1) ? 2 : 1))
                if (i - 1 >= 0 && j - 1 >= 0)
                {
                    PossibleMove(i - 1, j - 1);
                    if (simpleSteps[i - 1, j - 1].button.Background == Brushes.Green)
                    {
                        if (Meal is null)
                            Meal = new List<figure>();
                        Meal.Add(simpleSteps[i, j]);
                    }
                }
        }
        private void Food_3(int i, int j)
        {
            if (simpleSteps[i, j].Index == ((hod == 1) ? 2 : 1))
                if (i - 1 >= 0 && j + 1 < mapSize)
                {
                    PossibleMove(i - 1, j + 1);
                    if (simpleSteps[i - 1, j + 1].button.Background == Brushes.Green)
                    {
                        if (Meal is null)
                            Meal = new List<figure>();
                        Meal.Add(simpleSteps[i, j]);
                    }
                }
        }
        private void Food_4(int i, int j)
        {
            if (simpleSteps[i, j].Index == ((hod == 1) ? 2 : 1))

                if (i + 1 < mapSize && j + 1 < mapSize)
                {
                    PossibleMove(i + 1, j + 1);
                    if (simpleSteps[i + 1, j + 1].button.Background == Brushes.Green)
                    {
                        if (Meal is null)
                            Meal = new List<figure>();
                        Meal.Add(simpleSteps[i, j]);
                    }
                }
        }
        private void Food_5(int i, int j)
        {
            if (i + 1 < mapSize && j - 1 >= 0)
            {
                if (hod == 2)
                    PossibleMove(i + 1, j - 1);
                Food_1(i + 1, j - 1);
            }
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                if (hod == 2)
                    PossibleMove(i - 1, j - 1);
                Food_2(i - 1, j - 1);
            }
            if (i - 1 >= 0 && j + 1 < mapSize)
            {
                if (hod == 1)
                    PossibleMove(i - 1, j + 1);
                Food_3(i - 1, j + 1);
            }
            if (i + 1 < mapSize && j + 1 < mapSize)
            {
                if (hod == 1)
                    PossibleMove(i + 1, j + 1);
                Food_4(i + 1, j + 1);
            }
        }
    }
}