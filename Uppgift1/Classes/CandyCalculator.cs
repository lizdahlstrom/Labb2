using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace Uppgift1
{
    static class CandyCalculator
    {

        public static List<Person> DistributeCandies(List<Person> people, int numcandies)
        {
            if (!people.Any() || numcandies <= 0) return people;

            var remainder = (numcandies % people.Count);
            var evenCandies = (numcandies / people.Count);

            people.ForEach(person => person.Candies += evenCandies);

            if (remainder <= 0) return people;

            for (var i = 0; i < remainder; i++)
            {
                people[i].Candies++;
            }
            return people;
        }

    }
}
