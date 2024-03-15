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

namespace ListViewPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<People> peopleList = new List<People>();
        const string FILEPATH = @"..\..\people.txt";
        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            lvPeopleList.ItemsSource = peopleList;
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (File.Exists(FILEPATH))
            {
                List<String> list = new List<String>();
                foreach (var p in peopleList)
                {
                    list.Add(p.Name + ";" + p.Age );
                }
                File.WriteAllLines(FILEPATH, list);
            }
            else
            {
                Console.WriteLine("File {0} not exists", FILEPATH);
            }
        }

        private void InitializeData()
        {            
            if (File.Exists(FILEPATH))
            {
                var Lines = File.ReadLines(FILEPATH);
                foreach (var Line in Lines)
                {
                    var person = Line.Split(';');
                    People people = new People(person[0], Int32.Parse(person[1]));
                    peopleList.Add(people);
                }
            }
        }

        private void PeopleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPeopleList.SelectedItems.Count>0)
            {
                People curPeople = (People)lvPeopleList.SelectedItems[0];
                personName.Text = curPeople.Name;
                personAge.Text = curPeople.Age.ToString();
            }
        }

        private void personAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddPerson();            
        }

        private void AddPerson()
        {
            int age = int.Parse(personAge.Text);
            if (age < 150)
            {
                People newPerson = new People(personName.Text, age);
                peopleList.Add(newPerson);

                lvPeopleList.ItemsSource = null;
                lvPeopleList.ItemsSource = peopleList;
                lvPeopleList.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Age needs to be less than 150", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DeletePerson();
            AddPerson();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeletePerson();
        }

        private void DeletePerson()
        {
            if (lvPeopleList.SelectedIndex == -1)
            {
                MessageBox.Show("please choose a person");
                return;
            }
            People selectedForDelete = (People)lvPeopleList.SelectedItems[0];

            peopleList.Remove(selectedForDelete);

            lvPeopleList.ItemsSource = null;
            lvPeopleList.ItemsSource = peopleList;
        }
    }
}
