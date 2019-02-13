using System.Collections.Generic;
using System.Windows;
using Uppgift1.Classes;
using static Uppgift1.CandyCalculator;

namespace Uppgift1
{
    public partial class MainWindow : Window
    {
        private PeopleHandler pHandler;
        public MainWindow()
        {
            InitializeComponent();
            pHandler = new PeopleHandler();
            UpdateListBox();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbAge.Text, out var age))
            {
                ShowErrorMessage("Ogiltig inmatning av ålder.");
            }
            else
            {
                pHandler.People.Add(new Person(age, tbFirstName.Text, tbLastName.Text));
                ClearInputFields();
            }
        }

        private void DistributeCandy_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse((tbNumCandies.Text), out var numCandies))
            {
                ShowErrorMessage("Ogiltig inmatning av antal godisar.");
            }
            else
            {
                pHandler.People = DistributeCandies(pHandler.People, numCandies);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var person in listBoxPersons.SelectedItems)
            {
                pHandler.People.Remove((Person)person);
            }

            ClearInputFields();
        }

        private void ClearCandies_Click(object sender, RoutedEventArgs e)
        {
            pHandler.ClearCandies();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateListBox();
        }

        private void CheckBox_SortPeople(object sender, RoutedEventArgs e)
        {
            pHandler.SortPeople((bool)sortByAge.IsChecked);
            UpdateListBox();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            => pHandler.SaveToFile();

        // UI Methods
        private void UpdateListBox()
        {
            listBoxPersons.ItemsSource = null;
            listBoxPersons.ItemsSource = pHandler.People;
        }

        private void ClearInputFields()
        {
            tbAge.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
        }

        private static void ShowErrorMessage(string message) 
            => MessageBox.Show(message, "Ogiltig inmatning", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
