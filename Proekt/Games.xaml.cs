using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Window
    {
        const int mapSize = 8;
        figure[,] simpleSteps = new figure[mapSize, mapSize];
        int hod = 1;
        countFigure CountFigure = new countFigure();
        bool povtor = false;
        figure b = null;
        List<figure> Meal = null; // пешки которых можно съеть (лист)
        List<figure> lf = null; // возмоный ход (лист)
        List<figure> Meal_D1 = null; // 
        List<figure> Meal_D2 = null;//
        List<figure> Meal_D3 = null;//
        List<figure> Meal_D4 = null;//
        private new readonly Dictionary<string, MenuItem> Language = new Dictionary<string, MenuItem>();

        public Games()
        {
            InitializeComponent();
            this.Title = GamesLond.Title_1;
            SetDictionary();
            if (Info.IsNullFile())
                PM_1_5.IsEnabled = false;
            CreateMap();
        }

        private void SetDictionary()
        {
            Language.Add("en", PM_1_3_2);
            Language.Add("ru", PM_1_3_1);
            Language.Add("es", PM_1_3_3);
            Language.Add("fr", PM_1_3_4);
            Language_Changed(Thread.CurrentThread.CurrentUICulture.Parent.ToString());
        }

        private void Language_Changed(string s)
        {
            if (hod == 1)
                this.Title = GamesLond.Title_1;
            else
                this.Title = GamesLond.Title_2;
            PM_1.Header = GamesLond.PM_1;
            PM_1_1.Header = GamesLond.PM_1_1;
            PM_1_2.Header = GamesLond.PM_1_2;
            PM_1_3.Header = GamesLond.PM_1_3;
            PM_1_5.Header = GamesLond.PM_1_5;
            PM_1_3_1.Header = GamesLond.PM_1_3_1;
            PM_1_3_2.Header = GamesLond.PM_1_3_2;
            PM_1_3_3.Header = GamesLond.PM_1_3_3;
            PM_1_3_4.Header = GamesLond.PM_1_3_4;
            foreach (var el in Language)
                el.Value.IsEnabled = (el.Key != s) ? true : false;
        }

        public Games(int x)
        {
            InitializeComponent();
            SetDictionary();
            zagryzka();
        }

        private void PM_1_4_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateMap()
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
        private bool Food_6(List<figure> figures, int start, int end)
        {
            bool isFood = false;
            foreach (var m in figures)
                for (int a = start; a < end; a++)
                    if (m.Row == a)
                    {
                        izmenenie(m);
                        isFood = true;
                        break;
                    }
            return isFood;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (b is null)
            {
                foreach (var i in simpleSteps)
                    if ((Button)sender == i.button && i.Index == hod)
                    {
                        i.button.Background = Brushes.Red;
                        b = i;
                        Food_5(i.Row, i.Column, i.Dama);
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
                        bool isFood = false;
                        if (!(Meal is null))
                            isFood = Food_7(i);
                        i.Dama = b.Dama;
                        b.Dama = false;
                        if (!i.Dama && ((hod == 1 && i.Column == 7) || (hod == 2 && i.Column == 0)))
                            i.Dama = true;
                        i.Image();
                        if (isFood)
                        {
                            Food_8(i);
                            if (!(Meal is null))
                                return;
                        }
                        break;
                    }
                otmena();
                Perevod_hoda();
            }
        }

        private bool Food_7(figure i)
        {
            bool isFood = false;
            if (i.Dama)
            {
                if (!(Meal_D1 is null))
                {
                    if (b.Row < i.Row && b.Column > i.Column)
                        isFood = Food_6(Meal_D1, b.Row, i.Row);
                }
                if (!(Meal_D2 is null))
                {
                    if (b.Row > i.Row && b.Column > i.Column)
                        isFood = Food_6(Meal_D2, i.Row, b.Row);
                }
                if (!(Meal_D3 is null))
                {
                    if (b.Row > i.Row && b.Column < i.Column)
                        isFood = Food_6(Meal_D3, i.Row, b.Row);
                }
                if (!(Meal_D4 is null))
                {
                    if (b.Row < i.Row && b.Column < i.Column)
                        isFood = Food_6(Meal_D4, b.Row, i.Row);
                }
                return isFood;
            }
            else
            {
                foreach (var m in Meal)
                    if ((i.Row + 1 == m.Row || i.Row - 1 == m.Row) &&
                        (i.Column + 1 == m.Column || i.Column - 1 == m.Column))
                    {
                        izmenenie(m);
                        return true;
                    }

            }
            return false;
        }

        private void Food_8(figure i)
        {
            otmena();
            Food_5(i.Row, i.Column, i.Dama);
            if (!(Meal is null))
            {
                povtor = true;
                b = i;
                b.button.Background = Brushes.Red;
                if (i.Dama)
                {
                    if (Meal_D1 is null)
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row < lf[m].Row && b.Column > lf[m].Column)
                            {
                                lf[m].Background();
                                lf.RemoveAt(m);
                            }
                            else m++;
                    }
                    else
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row < lf[m].Row && b.Column > lf[m].Column)
                                if (Meal_D1[0].Row > lf[m].Row && Meal_D1[0].Column < lf[m].Column)
                                {
                                    lf[m].Background();
                                    lf.RemoveAt(m);
                                }
                                else
                                    m++;
                            else
                                break;
                    }
                    if (Meal_D2 is null)
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row > lf[m].Row && b.Column > lf[m].Column)
                            {
                                lf[m].Background();
                                lf.RemoveAt(m);
                            }
                            else m++;
                    }
                    else
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row > lf[m].Row && b.Column > lf[m].Column)
                                if (Meal_D2[0].Row < lf[m].Row && Meal_D2[0].Column < lf[m].Column)
                                {
                                    lf[m].Background();
                                    lf.RemoveAt(m);
                                }
                                else
                                    m++;
                            else
                                break;
                    }
                    if (Meal_D3 is null)
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row > lf[m].Row && b.Column < lf[m].Column)
                            {
                                lf[m].Background();
                                lf.RemoveAt(m);
                            }
                            else m++;
                    }
                    else
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row > lf[m].Row && b.Column < lf[m].Column)
                                if (Meal_D3[0].Row < lf[m].Row && Meal_D3[0].Column > lf[m].Column)
                                {
                                    lf[m].Background();
                                    lf.RemoveAt(m);
                                }
                                else
                                    m++;
                            else
                                break;
                    }
                    if (Meal_D4 is null)
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row < lf[m].Row && b.Column < lf[m].Column)
                            {
                                lf[m].Background();
                                lf.RemoveAt(m);
                            }
                            else m++;
                    }
                    else
                    {
                        for (var m = 0; m < lf.Count;)
                            if (b.Row < lf[m].Row && b.Column < lf[m].Column)
                                if (Meal_D4[0].Row > lf[m].Row && Meal_D4[0].Column > lf[m].Column)
                                {
                                    lf[m].Background();
                                    lf.RemoveAt(m);
                                }
                                else
                                    m++;
                            else
                                break;
                    }
                }
                else
                {
                    foreach (var s in lf)
                        if ((i.Row + 1 == s.Row || i.Row - 1 == s.Row) &&
                        (i.Column + 1 == s.Column || i.Column - 1 == s.Column))
                            s.Background();
                }
            }
        }

        private void izmenenie(figure m)
        {
            if (m.Index == 1)
                CountFigure.WhiteMoins();
            else
                CountFigure.BlackMoins();
            m.Index = 0;
            m.Image();
            m.Dama = false;
        }
        private void Perevod_hoda()
        {
            if (hod == 1)
            {
                hod = 2;
                Title = GamesLond.Title_2;
            }
            else
            {
                hod = 1;
                Title = GamesLond.Title_1;
            }
            povtor = false;
            int i = -1;
            if (CountFigure.Black() == 0)
                i = 0;
            else if (CountFigure.White() == 0)
                i = 1;
            else
            {
                if (!IsHod())
                    i = (hod == 1) ? 1 : 0;
                if (i == -1)
                {
                    bool Dama = true;
                    foreach (var f in simpleSteps)
                        if (f.Index != 0 && !(f.Dama))
                        {
                            Dama = false;
                            break;
                        }
                    if (Dama)
                    {
                        var w = new Message(4);
                        if (w.ShowDialog() == true)
                            i = 2;
                    }
                }
            }
            if (i != -1)
            {
                var w = new Message(i);
                if (w.ShowDialog() == false)
                    Close();
                else
                    NewGames();
            }
        }

        private void NewGames()
        {
            hod = 1;
            Title = GamesLond.Title_1;
            simpleSteps = new figure[mapSize, mapSize];
            CountFigure = new countFigure();
            CreateMap();
        }

        private bool IsHod()
        {
            foreach (var figure in simpleSteps)
                if (figure.Index == hod)
                {
                    Food_5(figure.Row, figure.Column, figure.Dama);
                    if (!(lf is null)) {
                        otmena();
                        return true;
                    }
                    otmena();
                }
            return false;
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
            Meal_D1 = null;
            Meal_D2 = null;
            Meal_D3 = null;
            Meal_D4 = null;
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
        private void Food_5(int i, int j, bool dama)
        {
            if (dama)
            {
                for (var a = 1; a < 8; a++)
                {
                    if (i + a < mapSize && j - a >= 0)
                    {
                        if (simpleSteps[i + a, j - a].Index == hod)
                            break;
                        PossibleMove(i + a, j - a);
                        Food_1(i + a, j - a);
                        if (i + a + 1 < mapSize && j - a - 1 >= 0)
                        {
                            if (simpleSteps[i + a, j - a].button.Background != Brushes.Green &&
                                simpleSteps[i + a + 1, j - a - 1].button.Background != Brushes.Green)
                                break;
                            if (simpleSteps[i + a + 1, j - a - 1].button.Background == Brushes.Green)
                            {
                                if (Meal_D1 is null)
                                    Meal_D1 = new List<figure>();
                                Meal_D1.Add(Meal[Meal.Count - 1]);
                            }
                        }
                    }
                    else
                        break;
                }
                for (var a = 1; a < 8; a++)
                {
                    if (i - a >= 0 && j - a >= 0)
                    {
                        if (simpleSteps[i - a, j - a].Index == hod)
                            break;
                        PossibleMove(i - a, j - a);
                        Food_2(i - a, j - a);
                        if (i - a - 1 >= 0 && j - a - 1 >= 0)
                        {
                            if (simpleSteps[i - a, j - a].button.Background != Brushes.Green &&
                                simpleSteps[i - a - 1, j - a - 1].button.Background != Brushes.Green)
                                break;
                            if (simpleSteps[i - a - 1, j - a - 1].button.Background == Brushes.Green)
                            {
                                if (Meal_D2 is null)
                                    Meal_D2 = new List<figure>();
                                Meal_D2.Add(Meal[Meal.Count - 1]);
                            }
                        }
                    }
                    else
                        break;
                }
                for (var a = 1; a < 8; a++)
                {
                    if (i - a >= 0 && j + a < mapSize)
                    {
                        if (simpleSteps[i - a, j + a].Index == hod)
                            break;
                        PossibleMove(i - a, j + a);
                        Food_3(i - a, j + a);
                        if (i - a - 1 >= 0 && j + a + 1 < mapSize)
                        {
                            if (simpleSteps[i - a, j + a].button.Background != Brushes.Green &&
                                simpleSteps[i - a - 1, j + a + 1].button.Background != Brushes.Green)
                                break;
                            if (simpleSteps[i - a - 1, j + a + 1].button.Background == Brushes.Green)
                            {
                                if (Meal_D3 is null)
                                    Meal_D3 = new List<figure>();
                                Meal_D3.Add(Meal[Meal.Count - 1]);
                            }
                        }
                    }
                    else
                        break;
                }
                for (var a = 1; a < 8; a++)
                {
                    if (i + a < mapSize && j + a < mapSize)
                    {
                        if (simpleSteps[i + a, j + a].Index == hod)
                            break;
                        PossibleMove(i + a, j + a);
                        Food_4(i + a, j + a);
                        if (i + a + 1 < mapSize && j + a + 1 < mapSize)
                        {
                            if (simpleSteps[i + a, j + a].button.Background != Brushes.Green &&
                                simpleSteps[i + a + 1, j + a + 1].button.Background != Brushes.Green)
                                break;
                            if (simpleSteps[i + a + 1, j + a + 1].button.Background == Brushes.Green)
                            {
                                if (Meal_D4 is null)
                                    Meal_D4 = new List<figure>();
                                Meal_D4.Add(Meal[Meal.Count - 1]);
                            }
                        }
                    }
                    else
                        break;
                }
            }
            else
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

        private void PM_1_1_Click(object sender, RoutedEventArgs e)
        {
            var s = new Message(5);
            if (s.ShowDialog() == true)
                NewGames();
        }

        private void PM_1_2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var file = new StreamWriter(Info.Path + Info.NameFile, false);
                file.WriteLine($"{hod}{CountFigure}");
                for (var i = 0; i < mapSize; i++)
                    for (var j = 0; j < mapSize; j++)
                        file.WriteLine(simpleSteps[i, j]);
                file.Close();
                PM_1_5.IsEnabled = true;
            }
            catch (Exception) { }
        }

        private void zagryzka()
        {
            try
            {
                if (File.Exists(Info.Path + Info.NameFile))
                {
                    string[] file = File.ReadAllLines(Info.Path + Info.NameFile);
                    if (file.Length == 0)
                        return;
                    simpleSteps = new figure[mapSize, mapSize];
                    if (!String.IsNullOrWhiteSpace(file[0]))
                    {
                        string[] stroka = file[0].Split(' ');
                        hod = Convert.ToInt32(stroka[0]);
                        int w = Convert.ToInt32(stroka[1]);
                        int b = Convert.ToInt32(stroka[2]);
                        CountFigure = new countFigure(w,b);
                    }
                    if (hod == 1)
                        this.Title = GamesLond.Title_1;
                    else
                        this.Title = GamesLond.Title_2;
                    for (int i = 1; i < file.Length; i++)
                        if (!String.IsNullOrWhiteSpace(file[i]))
                        {
                            string[] stroka = file[i].Split(' ');
                            var s1 = Convert.ToInt32(stroka[0]);
                            var s2 = Convert.ToInt32(stroka[1]);
                            var s3 = Convert.ToInt32(stroka[2]);
                            var s4 = Convert.ToBoolean(stroka[3]);
                            if (s1 < mapSize && s2 < mapSize)
                            {
                                simpleSteps[s1, s2] = new figure(s1, s2, s3, s4);
                                grids.Children.Add(simpleSteps[s1, s2].button);
                                Grid.SetColumn(simpleSteps[s1, s2].button, s1);
                                Grid.SetRow(simpleSteps[s1, s2].button, s2);
                                simpleSteps[s1, s2].button.Click += Button_Click;
                            }
                        }
                }
            }
            catch (Exception)
            {
                var s = new Message(7);
                if (s.ShowDialog() == true)
                    NewGames();
                else
                    Close();
            }
        }

        private void PM_1_3_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            foreach (var el in Language)
                if ((MenuItem)sender == el.Value)
                    s = el.Key;
            if (s.Length == 0)
                return;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(s);
            Language_Changed(s);
        }

        private void PM_1_5_Click(object sender, RoutedEventArgs e)
        {
            var s = new Message(6);
            if (s.ShowDialog() != true)
                return;
            zagryzka();
        }
    }
}
