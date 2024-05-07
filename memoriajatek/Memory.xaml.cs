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

namespace memoriajatek
{
    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>
    public partial class Memory : Window
    {
        public List<Button> buttons = new List<Button>();
        public List<int> numbers = new List<int>();
        public Memory(int number)
        {
            InitializeComponent();
            GridSetting(number);
           
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
            AddButtons(n);
        }

        public void AddButtons(int number)
        {
            for (int sor = 0; sor < number; sor++)
            {
                for(int oszlop = 0; oszlop < number; oszlop++)
                {
                    Button button = new Button();
                    button.FontSize = 30;
                    button.Click += ButtonClick;
                    Grid.SetRow(button, sor);
                    Grid.SetColumn(button, oszlop);
                    mainGrid.Children.Add(button);
                    buttons.Add(button);
                  


                }
            }
            Game(number);

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


            int[] asd = new int[2];
            for (int i = 0; i < asd.Length; i++)
            {
                asd[i] = int.Parse(button.Content.ToString());
            }
              
            

               
            
        }

      
    }
}
