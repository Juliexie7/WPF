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
using System.Windows.Shapes;

namespace Cars
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public event Action<string,double,string> Update_Car;
        public Update(Car mycar)
        {
            InitializeComponent();
            modelText.Text = mycar.Model;
            sizeText.Text = mycar.Engine.ToString();
            slEngine.Value = mycar.Engine;
            fuel.Text = mycar.Fuel;
        }

        private void bnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (modelText.Text == "")
            {
                MessageBox.Show("Please enter the make model!");
                return;
            }
            Update_Car?.Invoke(modelText.Text, slEngine.Value, fuel.Text);
            DialogResult = true;
        }

        private void modelText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[,;]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void slEngine_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sizeText.Text = slEngine.Value.ToString();
        }

        private void bnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
