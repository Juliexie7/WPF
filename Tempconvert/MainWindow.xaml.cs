using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool inited = false;
        public MainWindow()
        {
            InitializeComponent();
            inited = true;
            Caculate();
        }

        private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (inited)
            {
                Caculate();
            }
        }

        private void myTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox box)
            {
                if (box.Text.Equals("0.00"))
                    box.Text = null;
            }
        }

        private void Caculate()
        {
            var x = myTextBox.Text;
            double Temperature;
            if (double.TryParse(x, out Temperature))
            {
                if ((bool)Celcius1.IsChecked && (bool)Celcius2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}",myTextBox.Text, "°C");
                }
                if ((bool)Celcius1.IsChecked && (bool)Farenheit2.IsChecked)
                {                    
                    myOutput.Text = string.Format("{0}{1}", (Temperature * 9 / 5) + 32, "°F");
                }
                if ((bool)Celcius1.IsChecked && (bool)Kelvin2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", Temperature + 273.15, "K");
                }
                if ((bool)Farenheit1.IsChecked && (bool)Celcius2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", Math.Round((Temperature - 32) * 5 / 9, 2), "°C");
                }
                if ((bool)Farenheit1.IsChecked && (bool)Farenheit2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", myTextBox.Text, "°F");
                }
                if ((bool)Farenheit1.IsChecked && (bool)Kelvin2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", Math.Round((Temperature - 32) * 5 / 9, 2) + 273.15, "K");
                }
                if ((bool)Kelvin1.IsChecked && (bool)Celcius2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", Temperature - 273.15, "°C");
                }
                if ((bool)Kelvin1.IsChecked && (bool)Farenheit2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", (Temperature - 273.15) * 9 / 5 + 32, "°F");
                }
                if ((bool)Kelvin1.IsChecked && (bool)Kelvin2.IsChecked)
                {
                    myOutput.Text = string.Format("{0}{1}", myTextBox.Text, "K");
                }

            }
        }

        private void OnRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (inited)
            {
                Caculate();
            }            
        }
    }
}
