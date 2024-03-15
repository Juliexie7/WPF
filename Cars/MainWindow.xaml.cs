using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FILEPATH = @"..\..\cars.txt";
        List<Car> Carlist = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFile();
        }

        private void LoadFile()
        {
            if (File.Exists(FILEPATH))
            {               
                var Lines = File.ReadAllLines(FILEPATH);
                foreach (var line in Lines)
                {
                    var mycar = line.Split(';');
                    if (double.TryParse(mycar[1], out double size))
                    {
                        if (mycar.Length > 2)
                        {
                            Carlist.Add(new Car(mycar[0], size, mycar[2]));
                        }
                    }
                }
                lvCars.ItemsSource = Carlist;
            }
        }

        private void menuCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Save the cars in a file";

            if (saveFileDialog.ShowDialog() == true)
            {
                string allData = "";
                foreach (Car myCar in Carlist)
                {
                    allData += myCar.toCSVString() + "\n";
                }
                File.WriteAllText(saveFileDialog.FileName, allData);
            }
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuAdd_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.Owner = this;
            add.Add_Car += (car) => { Carlist.Add(car); };
            add.ShowDialog();
            lvCars.Items.Refresh();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvCars.Items.Count == 0)
            {
                return;
            }
            //if user doesn't choose any item
            if (lvCars.SelectedIndex == -1)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                var selectedForDelete = lvCars.SelectedItems;

                foreach (Car item in selectedForDelete)
                {
                    Carlist.Remove(item);
                }

                lvCars.Items.Refresh();
            }

        }

        private void Winow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(FILEPATH))
            {
                foreach (Car myCar in Carlist)
                {
                    writer.WriteLine(myCar.toDataString());
                }
            }
        }

        private void lvCars_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Car myCar = (Car)lvCars.SelectedItems[0];
            Update update = new Update(myCar);           

            update.Update_Car += (model, engine, fuel) => {
                myCar.Model = model;
                myCar.Engine = engine;
                myCar.Fuel = fuel;
            };

            update.ShowDialog();

            lvCars.Items.Refresh();
        }
    }
}
