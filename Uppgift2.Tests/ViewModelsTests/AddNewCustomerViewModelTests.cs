using Uppgift2.ViewModels;
using Xunit;

namespace Uppgift2.Tests.ViewModelsTests
{
    public class AddNewCustomerViewModelTests
    {
        [Fact]
        public static void FirstName_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.FirstName);
        }

        [Fact]
        public static void Last_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.LastName);
        }

        [Fact]
        public static void SSN_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.SSN);
        }

        [Fact]
        public static void PhoneNumber_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.PhoneNumber);
        }
        [Fact]
        public static void Zip_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.Zip);
        }
        [Fact]
        public static void Street_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.Street);
        }
        [Fact]
        public static void City_ShouldNotBeNull()
        {
            var viewModel = new AddNewCustomerViewModel(new BankViewModel());

            Assert.NotNull(viewModel.City);
        }

    }
}
