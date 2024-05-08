using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace memoriajatek
{
    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>
    public partial class Memory : Window
    {
        public List<Button> buttons = new List<Button>();
        public List<Button> buttons2 = new List<Button>();
        public List<int> numbers = new List<int>();
        public int[] ints = new int[2];
        public List<Button> hiddenButtons = new List<Button>();
        DispatcherTimer timer;
        public int counter = 0;
        public int index = 0;
        public bool messageBoxShow = false;
        public Memory(int number)
        {
            InitializeComponent();
            GridSetting(number);
            AddButtons(number);
            SecondLayerAddButtons(number);
            timer = new DispatcherTimer();
        }

        public void GridSetting(int n)
        {
            for (int i = 0; i < n; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());



            }
            for (int i = 0; i < n; i++)
            {

                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
        }

        public void AddButtons(int number)
        {
            for (int sor = 0; sor < number; sor++)
            {
                for(int oszlop = 0; oszlop < number; oszlop++)
                {
                    Button button = new Button();
                    button.FontSize = 30;
                    button.Background = Brushes.Yellow;   
                    Grid.SetRow(button, sor);
                    Grid.SetColumn(button, oszlop);
                    mainGrid.Children.Add(button);
                    buttons.Add(button);
                  


                }
            }
            Game(number);

        }
        public void SecondLayerAddButtons(int number)
        {
            for (int sor = 0; sor < number; sor++)
            {
                for (int oszlop = 0; oszlop < number; oszlop++)
                {
                    Button button = new Button();
                    button.FontSize = 30;
                    button.Click += ButtonClick;
                    button.Content = " ";
                    Grid.SetRow(button, sor);
                    Grid.SetColumn(button, oszlop);
                    mainGrid.Children.Add(button);
                    buttons2.Add(button);



                }
            }
        }

        public void Game(int number)
        {

            for (int i = 1; i <= number * number / 2; i++)
            {
                numbers.Add(i);
                numbers.Add(i);
            }

            List<int> numberList = GenerateRandomOrderBy(numbers);
            
            int[] numberArray = new int[numberList.Count];

            int index = 0;
            foreach (int item in numberList)
            {
                numberArray[index] = item;
                index++;
            }
            index = 0;

            foreach (Button item in buttons)
            {
                item.Content = numberArray[index];
                index++;
            }



           

            
        }

        public List<int> GenerateRandomOrderBy(List<int> numbers)
        {
            Random rand = new Random();
            var shuffledList = numbers.OrderBy(asd => rand.Next()).ToList();
            
            return shuffledList;
        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Visibility = Visibility.Hidden;
            hiddenButtons.Add(button);
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            Button buttonsListContent = buttons.Find(b => Grid.GetRow(b) == row && Grid.GetColumn(b) == column);
            int szam = int.Parse(buttonsListContent.Content.ToString());
           
            
            ints[index] = szam;
            if (index < 2)
            {
                if(hiddenButtons.Count == 2)
                {
                    foreach (Button item1 in hiddenButtons)
                    {
                        foreach (Button item2 in buttons2)
                        {
                            if (item1 != item2)
                            {
                                item2.IsEnabled = false;
                            }
                        }
                    }
                }
               
               
                

                if (ints[0] != 0 && ints[1] != 0)
                {

                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (s, args) =>
                    {
                        counter++;
                        if (ints[0] != ints[1])
                        {
                            if (counter == 1)
                            {
                                timer.Stop();
                                foreach (Button item in hiddenButtons)
                                {
                                    item.Visibility = Visibility.Visible;
                                }
                                foreach (Button item2 in buttons2)
                                {

                                    item2.IsEnabled = true;

                                }
                                hiddenButtons.Clear();
                                counter = 0;
                                
                            }
                        }
                        else
                        {
                            timer.Stop();
                            foreach (Button item1 in hiddenButtons)
                            {
                                foreach (Button item2 in buttons2)
                                {
                                    if (item1 == item2)
                                    {
                                        buttons2.Remove(item1);
                                        return;
                                    }
                                }
                            }
                            foreach(Button item2 in buttons2)
                            {
                                item2.IsEnabled = true;
                            }

                            hiddenButtons.Clear();
                            counter = 0;


                        }
                    };
                   
                    timer.Start();
 
                }
                index++;
            }
           

            if (index == 2)
            {
                index = 0;
            }
            //if (win)
            //{
                
            //}
            

        }

    }
}
