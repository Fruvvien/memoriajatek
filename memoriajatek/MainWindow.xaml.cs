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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace memoriajatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
        }


      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedNumber = (ListBoxItem)mainListBox.SelectedItem;
            var num = selectedNumber.Content.ToString();

            int n = Int32.Parse(num);
            Memory memory = new Memory(n);
            this.Hide();
            memory.Show();
        }
    }
}
