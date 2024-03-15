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

namespace Todo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FILEPATH = @"..\..\exported_file.txt";
        List<TodoInfo> TodoList = new List<TodoInfo>();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            lvTodo.ItemsSource = TodoList;
        }

        private void LoadData()
        {
            if (File.Exists(FILEPATH))
            {
                var Lines = File.ReadAllLines(FILEPATH);
                foreach (var Line in Lines)
                {
                    /*                  string input = "abc][rfd][5][,][.";
                                        string[] parts1 = input.Split(new string[] { "][" }, StringSplitOptions.None);
                                        string[] parts2 = Regex.Split(input, @"\]\[");*/
                    var Fields = Line.Split(new char[] { ';' });
/*                    if (!DateTime.TryParse(Fields[1], out var date))
                    {
                        MessageBox.Show("an error happened in reading the file");
                    }*/
                    if (!int.TryParse(Fields[2],out int difficulty))
                    {
                        MessageBox.Show("an error happened in reading the file");
                    }
                    TodoInfo newItem = new TodoInfo(Fields[0], Fields[1], difficulty, Fields[3]);
                    TodoList.Add(newItem);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void lvTodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;

            var seletedItem = lvTodo.SelectedItem;
            if (seletedItem is TodoInfo)
            {
                TodoInfo todoItem = (TodoInfo)seletedItem;
                textTask.Text = todoItem.Task;

            }
        }
    }
}
