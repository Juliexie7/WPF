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
using System.Xml.Linq;

namespace FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                FetchRecord();
                Clear();

            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FetchRecord()
        {
            lvPassport.ItemsSource = Global.ctx.Passports.ToList();
        }

        private void lvPassport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPassport.SelectedIndex == -1)
            {
                Clear();
                return;
            }
            Passport p = (Passport)lvPassport.SelectedItem;
            lbId.Content = p.Id;
            tbFirstName.Text = p.FirstName;
            tbLastName.Text = p.LastName;
            tbPassport.Text = p.PassportNo;
            dpExpirDate.Text = p.ExpirDate;
            cbIsValid.IsChecked = p.IsValid;
            btnInsert.Content = "Update";
            btnDelete.IsEnabled = true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsValid()) { return; }
            try
            {
                if (lvPassport.SelectedIndex == -1)
                {
                    Passport p = new Passport(tbFirstName.Text, tbLastName.Text, tbPassport.Text, dpExpirDate.Text, (bool)cbIsValid.IsChecked);
                    Global.ctx.Passports.Add(p);
                    Global.ctx.SaveChanges();
                } else
                {
                    Passport p = (Passport)lvPassport.SelectedItem;
                    if (p == null) { return; }
                    p.FirstName = tbFirstName.Text;
                    p.LastName = tbLastName.Text;
                    p.PassportNo = tbPassport.Text;
                    p.ExpirDate = dpExpirDate.Text;
                    p.IsValid = (bool)cbIsValid.IsChecked;
                    Global.ctx.SaveChanges();
                }

                Clear();
                FetchRecord();
            }
            catch (SystemException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool IsFieldsValid()
        {
            if (tbFirstName.Text.Length < 2 || tbFirstName.Text.Length > 100)
            {
                MessageBox.Show("First Name must be between 2 and 100 characters", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (tbLastName.Text.Length < 2 || tbLastName.Text.Length > 100)
            {
                MessageBox.Show("Last Name must be between 2 and 100 characters", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (tbPassport.Text.Length != 10 || !int.TryParse(tbPassport.Text, out int passportNo))
            {
                MessageBox.Show("Passport Number must be 10 digits", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (dpExpirDate.Text.Length == 0)
            {
                MessageBox.Show("Please choose Expiration Date", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lbId.Content = "... ";
            tbFirstName.Text = string.Empty;
            tbLastName.Text = string.Empty;
            tbPassport.Text = string.Empty;
            dpExpirDate.Text = string.Empty;
            cbIsValid.IsChecked = false;
            btnInsert.Content = "Insert";
            btnDelete.IsEnabled = false;
            lvPassport.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Passport p = (Passport)lvPassport.SelectedItem;
            if (p == null) { return; }
            if (MessageBoxResult.Yes != MessageBox.Show("Do you want to delete ? \n", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                return;
            }
            try
            {
                Global.ctx.Passports.Remove(p);
                Global.ctx.SaveChanges();
                Clear();
                FetchRecord();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
