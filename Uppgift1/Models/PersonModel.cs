using System;

namespace Uppgift1.Models
{
    [Serializable()]
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; }
        public int Candies { get; set; }
        public DateTime DateAdded { get; } = DateTime.Now;

        public PersonModel(int age, string firstName, string lastName)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
