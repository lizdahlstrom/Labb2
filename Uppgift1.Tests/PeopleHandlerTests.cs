using Uppgift1.Classes;
using Xunit;

namespace Uppgift1.Tests
{
    public class PeopleHandlerTests
    {
        [Fact]
        public static void LoadPeople_ShouldReturnAList()
        {
            var actual = PeopleHandler.LoadPeople();

            Assert.NotNull(actual);
        }
    }
}
