using System.Collections.Generic;
using System.Linq;
using Uppgift1.Models;

namespace Uppgift1
{
    public static class CandyCalculator
    {
        public static List<PersonModel> DistributeCandies(List<PersonModel> people, int numCandies)
        {
            if (!people.Any() || numCandies <= 0) return people;

            var remainder = (numCandies % people.Count);
            var evenCandies = (numCandies / people.Count);

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
