using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MidExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FILEPATH = @"..\..\trips.txt";
        List<Trip> TripList = new List<Trip>();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(FILEPATH))
            {
                using (StreamReader sr = new StreamReader(FILEPATH))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] myData = line.Split(';');
                        DateTime myDepartureDt, myReturnDt;
                        if (!DateTime.TryParse(myData[3], out myDepartureDt))
                        {
                            throw new InvalidDataException("Invalid Departure Date");
                        }
                        if (!DateTime.TryParse(myData[4], out myReturnDt))
                        {
                            throw new InvalidDataException("Invalid Return Date");
                        }

                        Trip mytrip = new Trip(myData[0], myData[1], myData[2], myDepartureDt, myReturnDt);
                        TripList.Add(mytrip);

                        line = sr.ReadLine();
                    }
                }

                lvList.ItemsSource = TripList;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(FILEPATH))
            {
                foreach (Trip myTrip in TripList)
                {
                    sw.WriteLine(myTrip.ToDataString());
                }
            }
        }

        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            var selectedItem = lvList.SelectedItem;

            if (selectedItem is Trip)
            {
                Trip myTrip = (Trip)selectedItem;
                txtDestination.Text = myTrip.Destination;
                txtName.Text = myTrip.Name;
                txtPassport.Text = myTrip.Passport;
                dpDeparture.SelectedDate = myTrip.DepartureDt;
                dpReturn.SelectedDate = myTrip.ReturnDt;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate1 = dpDeparture.SelectedDate;
            DateTime? selectedDate2 = dpReturn.SelectedDate;

            if (txtDestination.Text == "" || txtName.Text == "" || txtPassport.Text == "" || selectedDate1 == null || selectedDate2 == null)
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try {
                Trip mytrip = new Trip(txtDestination.Text, txtName.Text, txtPassport.Text, (DateTime)selectedDate1, (DateTime)selectedDate2);
                TripList.Add(mytrip);
                ResetValues();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ResetValues()
        {
            lvList.Items.Refresh();
            txtDestination.Clear();
            txtName.Clear();
            txtPassport.Clear();
            dpDeparture.Text = "";
            dpReturn.Text = "";
            lvList.SelectedIndex = -1;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false; 
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvList.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Trip tripTobeDeleted = (Trip)lvList.SelectedItem;
            if (tripTobeDeleted != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete the trip?", "CONFIRMATION", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    TripList.Remove(tripTobeDeleted);
                    ResetValues();
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate1 = dpDeparture.SelectedDate;
            DateTime? selectedDate2 = dpReturn.SelectedDate;
            if (lvList.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtDestination.Text == "" || txtName.Text == "" || txtPassport.Text == "" || selectedDate1 == null || selectedDate2 == null)
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (DateTime.Parse(dpDeparture.Text) > DateTime.Parse(dpReturn.Text))
            {
                MessageBox.Show("Departure Date can't be after Return date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Trip tripTobeUpdated = (Trip)lvList.SelectedItem;
            tripTobeUpdated.Destination = txtDestination.Text;
            tripTobeUpdated.Name = txtName.Text;
            tripTobeUpdated.Passport = txtPassport.Text;
            tripTobeUpdated.DepartureDt = DateTime.Parse(dpDeparture.Text);
            tripTobeUpdated.ReturnDt = DateTime.Parse(dpReturn.Text);

            ResetValues();
        }

        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[;]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "trip files (*.trips)|*.trips|All files (*.*)|*.*";
            saveFileDialog.Title = "Save trips in a file";
            if (saveFileDialog.ShowDialog() == true)
            {
                string allData = "";
                foreach (Trip mytrip in TripList)
                {
                    allData += mytrip.ToString() + "\n";
                }
                File.WriteAllText(saveFileDialog.FileName, allData);
            }
        }
    }
}
