using CarDB.Domain;
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

namespace CarDB
{
    /// <summary>
    /// Interaction logic for CarsDialog.xaml
    /// </summary>
    public partial class CarsDialog : Window
    {
        List<Car> cars = Global.context.cars.ToList<Car>();
        Owner owner;
        int ownerId;
        public CarsDialog(int owner_Id, string ownerN)
        {
            InitializeComponent();
            ownerId = owner_Id;
            owner = (from o in Global.context.owners where o.Id == ownerId select o).FirstOrDefault<Owner>();
            ownerName.Text = ownerN;
            LoadData();
        }

        private void LoadData()
        {
            cars = (from c in Global.context.cars where c.Owner.Id == ownerId select c).ToList<Car>();
            lvCar.ItemsSource = cars;
            lvCar.Items.Refresh();
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            lvCar.SelectedIndex = -1;
            carId.Text = "";
            makeModel.Clear();
        }

        private void lvCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCar = lvCar.SelectedItem;

            if (selectedCar is Car)
            {
                Car car = (Car)selectedCar;                
                carId.Text = car.Id.ToString();
                makeModel.Text = car.MakeModel;

                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string make = makeModel.Text;            
            
            Car car = new Car(make, owner);
            owner.CarNo += 1;
            Global.context.cars.Add(car);
            Global.context.SaveChanges();
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvCar.SelectedIndex == -1)
            {
                return;
            }

            Car carToBeUpdated = (Car)lvCar.SelectedItem;
            carToBeUpdated.MakeModel = makeModel.Text;

            Global.context.SaveChanges();
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvCar.SelectedIndex == -1)
            {
                return;
            }

            Car carToBeDeleted = (Car)lvCar.SelectedItem;
            Global.context.cars.Remove(carToBeDeleted);
            owner.CarNo--;
            Global.context.SaveChanges();

            LoadData();
        }
    }
}
