using Uppgift2.ViewModels;
using Xunit;

namespace Uppgift2.Tests.ViewModelsTests
{
    public class BankViewModelTests
    {
        [Fact]
        public static void AddNewCustomerViewModel_ShouldNotBeNull()
        {
            var bankViewModel = new BankViewModel();

            Assert.NotNull(bankViewModel.AddNewCustomerViewModel);
        }

        [Fact]
        public static void ManageAccountViewModel_ShouldNotBeNull()
        {
            var bankViewModel = new BankViewModel();

            Assert.NotNull(bankViewModel.ManageAccountsViewModel);
        }
    }
}
