using Uppgift1.ViewModels;
using Xunit;

namespace Uppgift1.Tests
{
    public class ViewModelTest
    {
        [Fact]
        public static void FirstName_ShouldNotReturnNull()
        {
            var vm = new ShellViewModel();

            var actual = vm.FirstName;

            Assert.NotNull(actual);
        }

        [Fact]
        public static void LastName_ShouldNotReturnNull()
        {
            var vm = new ShellViewModel();

            var actual = vm.LastName;

            Assert.NotNull(actual);
        }

        [Fact]
        public static void People_ShouldNotReturnNull()
        {
            var vm = new ShellViewModel();

            var actual = vm.People;

            Assert.NotNull(actual);
        }

        [Fact]
        public static void Age_ShouldBeInRange()
        {
            var vm = new ShellViewModel();
            var minAge = 0;
            var maxAge = 130;

            var actual = vm.Age;

            Assert.InRange(actual, minAge,maxAge);
        }
    }
}
