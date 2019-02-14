using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using Uppgift1.Classes;
using Uppgift1.Models;

namespace Uppgift1.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _firstName = "";
        private string _lastName = "";
        private int _age;
        private BindableCollection<PersonModel> _people;
        private PersonModel _selectedPerson;
        public int NumOfCandies { get; set; }
        public bool IsSortByAgeSelected { get; set; }

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; NotifyOfPropertyChange(() => FirstName); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; NotifyOfPropertyChange(() => LastName); }
        }

        public int Age
        {
            get => _age;
            set { _age = value; NotifyOfPropertyChange(() => Age); }
        }

        public BindableCollection<PersonModel> People
        {
            get => _people;
            set { _people = value; NotifyOfPropertyChange(() => People); }
        }

        public PersonModel SelectedPerson
        {
            get => _selectedPerson;
            set { _selectedPerson = value; NotifyOfPropertyChange(() => SelectedPerson); }
        }

        public ShellViewModel()
        {
            People = new BindableCollection<PersonModel>(PeopleHandler.LoadPeople());
        }

        public bool CanAddPerson(int age, string firstName, string lastName)
        {
            return !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && age > 0;
        }

        public void AddPerson(int age, string firstName, string lastName)
        {
            People.Add(new PersonModel(Age, FirstName, LastName));

            Age = 0;
            FirstName = "";
            LastName = "";

            SortPeople();
        }

        public bool CanDistributeCandies(int numOfCandies) => numOfCandies > 0;

        public void DistributeCandies(int numOfCandies)
        {
            People = new BindableCollection<PersonModel>
                (CandyCalculator.DistributeCandies(People.ToList(), NumOfCandies));
        }

        public void ClearPeople()
        {
            if (SelectedPerson == null)
                People.Clear();
            else
                People.Remove(SelectedPerson);
        }

        public void ClearCandies()
        {
            if (People == null)
                return;

            var list = new List<PersonModel>(People);
            list.ForEach(p => p.Candies = 0);
            People = new BindableCollection<PersonModel>(list);
        }

        public void SortPeople()
        {
            People = new BindableCollection<PersonModel>(IsSortByAgeSelected
                ? People.OrderBy(person => person.Age).ToList()
                : People.OrderBy(person => person.DateAdded).ToList());
        }

        protected override void OnDeactivate(bool close) => PeopleHandler.SaveToFile(People.ToList());
    }
}
