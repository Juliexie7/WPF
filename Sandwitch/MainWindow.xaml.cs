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

namespace Sandwitch
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
            Window1 window1 = new Window1();
            window1.Owner = this;            

            window1.AssignResult += (bread1, vegetable1, meat1) =>
            {
                bread.Text = bread1;
                veggis.Text = vegetable1;
                meat.Text = meat1;
            };

            bool? result = window1.ShowDialog();

            //if (result == true)
            //{
            //    MessageBox.Show(bread.Text);
            //}
        }
    }
}
