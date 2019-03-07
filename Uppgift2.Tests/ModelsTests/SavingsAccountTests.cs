using Uppgift2.Models.Accounts;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class SavingsAccountTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(10, 9.9999)]
        [InlineData(8.1, 8)]
        public static void Withdraw_ShouldReturnTrue_When_FundsAreSufficient(double deposit, double withdraw)
        {
            var account = new SavingsAccount("123");
            account.Deposit(deposit);

            Assert.True(account.WithDraw(withdraw));
        }

        [Fact]
        public static void Withdraw_ShouldReturnFalse_When_FundsAreNotSufficient()
        {
            var account = new SavingsAccount("123");

            Assert.False(account.WithDraw(1));
        }
    }
}
