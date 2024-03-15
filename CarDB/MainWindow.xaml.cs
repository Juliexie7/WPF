using CarDB.Domain;
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
using System.Xml.Linq;

namespace CarDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Owner> owners = Global.context.owners.ToList<Owner>();
        string filePath = null;
        public MainWindow()
        {
            InitializeComponent();            
            LoadData();
        }

        private void LoadData()
        {
            owners = Global.context.owners.ToList<Owner>();
            lvOwner.ItemsSource = owners;
            lvOwner.Items.Refresh();
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnMCar.IsEnabled = false;
            lvOwner.SelectedIndex = -1;
            ownerId.Text = "";
            ownerName.Clear();
            ownerPhoto.Source = null;
            filePath = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = ownerName.Text;
            string photo = null;
            if (filePath != null)
            {
                photo = filePath;
            }

            Owner owner = new Owner(name, photo, 0);
            Global.context.owners.Add(owner);
            Global.context.SaveChanges();
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvOwner.SelectedIndex == -1)
            {
                return;
            }

            Owner ownerToBeUpdated = (Owner)lvOwner.SelectedItem;
            ownerToBeUpdated.Name = ownerName.Text;
            if (filePath != null)
            {
                ownerToBeUpdated.Photo = filePath;
            }
            Global.context.SaveChanges();
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvOwner.SelectedIndex == -1)
            {
                return;
            }

            Owner ownerToBeDeleted = (Owner)lvOwner.SelectedItem;
            Global.context.owners.Remove(ownerToBeDeleted);
            Global.context.SaveChanges();

            LoadData();
        }

        private void btnMCar_Click(object sender, RoutedEventArgs e)
        {
            if (lvOwner.SelectedIndex == -1)
            {
                return;
            }

            Owner ownerToBeModify = (Owner)lvOwner.SelectedItem;
            CarsDialog carsDialog = new CarsDialog(ownerToBeModify.Id, ownerToBeModify.Name);
            carsDialog.Owner = this; // it helps to open the new dialog near the parent position            

            bool? result = carsDialog.ShowDialog();
            LoadData();
        }

        private void lvOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedOwner = lvOwner.SelectedItem;

            if (selectedOwner is Owner) // instance of
            {
                Owner owner = (Owner)selectedOwner;
                ownerId.Text = owner.Id.ToString();
                ownerName.Text = owner.Name;
                if (owner.Photo != null)
                {
                    var uriSource = new Uri(owner.Photo);

                    ownerPhoto.Source = new BitmapImage(uriSource);
                } else { ownerPhoto.Source = null; }

                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnMCar.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //https://www.c-sharpcorner.com/UploadFile/mahesh/openfiledialog-in-C-Sharp/
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select Photos";
            if (openFileDialog1.ShowDialog() == true)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                var uriSource = new Uri(filePath);

                ownerPhoto.Source = new BitmapImage(uriSource);
            }
        }
    }
}
