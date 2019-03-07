using Uppgift2.ViewModels;
using Xunit;

namespace Uppgift2.Tests.ViewModelsTests
{
    public class ManageAccountsViewModelTests
    {
        [Fact]
        public static void BankViewModel_ShouldNotBeNull()
        {
            var viewModel = new ManageAccountsViewModel(new BankViewModel());

            Assert.NotNull(viewModel.BankViewModel);
        }

        [Fact]
        public static void Accounts_ShouldNotBeNull()
        {
            var viewModel = new ManageAccountsViewModel(new BankViewModel());

            Assert.NotNull(viewModel.Accounts);
        }

        [Fact]
        public static void Transactions_ShouldNotBeNull()
        {
            var viewModel = new ManageAccountsViewModel(new BankViewModel());

            Assert.NotNull(viewModel.Transactions);
        }
        [Fact]
        public static void AccountType_ShouldNotBeNull()
        {
            var viewModel = new ManageAccountsViewModel(new BankViewModel());

            Assert.NotNull(viewModel.AccountType);
        }

        [Fact]
        public static void TransactionType_ShouldNotBeNull()
        {
            var viewModel = new ManageAccountsViewModel(new BankViewModel());

            Assert.NotNull(viewModel.TransactionType);
        }

    }
}
