using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Uppgift1.Classes
{
    class PeopleHandler
    {
        private const string FileName = "people.bin";
        public List<Person> People { get; set; }

        public PeopleHandler()
        {
            LoadPeople();
        }

        private void LoadPeople()
        {
            People = File.Exists(FileName) ? (List<Person>)FileOperations.Deserialize(FileName) : new List<Person>();
        }

        public void SaveToFile()
        {
            FileOperations.Serialize(People, FileName);
        }

        public void SortPeople(bool sortByAge)
        {
            People = sortByAge ? People.OrderBy(person => person.Age).ToList() : People.OrderBy(person => person.DateAdded).ToList();
        }

        public void ClearCandies()
        {
            People.ForEach(person => person.Candies = 0);
        }
    }
}
