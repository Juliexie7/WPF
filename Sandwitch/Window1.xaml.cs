using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
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
using System.Windows.Shapes;

namespace Sandwitch
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public event Action<string, string, string> AssignResult;
        public Window1()
        {
            InitializeComponent();
        }


        private void save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedBread = (ComboBoxItem)bread.SelectedItem;
            string vegtable = "";
            if (lettuce.IsChecked == true)
            {
                vegtable += "lettuce";
            }
            if (tomato.IsChecked == true)
            {
                if (vegtable != "")
                {
                    vegtable += ",";
                }
                vegtable += "tomato";
            }
            if (cucumber.IsChecked == true)
            {
                if (vegtable != "")
                {
                    vegtable += ",";
                }
                vegtable += "cucumber";
            }

            string meat = "";
            if (chicken.IsChecked == true)
            {
                meat = "chicken";
            } else if (turki.IsChecked == true)
            {
                meat = "turki";
            }
            else if (tofu.IsChecked == true)
            {
                meat = "tofu";
            }
            
            AssignResult?.Invoke(selectedBread.Content.ToString(), vegtable, meat);
            DialogResult = true;

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
