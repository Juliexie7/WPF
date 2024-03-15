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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public event Action<Car> Add_Car;
        public Add()
        {
            InitializeComponent();
        }

        private void bnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bnSave_Click(object sender, RoutedEventArgs e)
        {
            if (modelText.Text == "")
            {
                MessageBox.Show("Please enter the make model!");
                return;
            }
            Car myCar = new Car(modelText.Text, slEngine.Value, fuel.Text);
            Add_Car?.Invoke(myCar);
            DialogResult = true;
        }

        private void slEngine_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sizeText.Text = slEngine.Value.ToString();
        }

        private void modelText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[,;]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
