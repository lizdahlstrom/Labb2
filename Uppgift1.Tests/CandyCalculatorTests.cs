using System.Collections.Generic;
using Uppgift1.Models;
using Xunit;

namespace Uppgift1.Tests
{
    public class CandyCalculatorTests
    {

        [Fact]
        public static void DistributeCandies_ShouldReturnSameList()
        {
            var numCandies = 13;
            var people = new List<PersonModel>()
            {
                new PersonModel(12,"Person", "A"),
                new PersonModel(34,"Person", "B"),
                new PersonModel(5,"Person", "C"),
                new PersonModel(8,"Person", "D"),
                new PersonModel(6,"Person", "E")
            };

            var actual = CandyCalculator.DistributeCandies(people, numCandies);

            Assert.Same(actual, people);
        }
    }
}
