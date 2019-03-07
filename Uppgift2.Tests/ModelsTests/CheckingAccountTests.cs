using Uppgift2.Models.Accounts;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class CheckingAccountTests
    {
        [Fact]
        public static void Withdraw_ShouldReturnTrue_When_FundsAreSufficient()
        {
            var account = new CheckingAccount("123");
            account.Deposit(2);

            Assert.True(account.WithDraw(1));
        }

        [Fact]
        public static void Withdraw_ShouldReturnFalse_When_FundsAreNotSufficient()
        {
            var account = new CheckingAccount("123",0);

            Assert.False(account.WithDraw(1));
        }

        [Fact]
        public static void Withdraw_ShouldReturnTrue_When_CreditIsSufficient()
        {
            var account = new CheckingAccount("123", 1);

            Assert.True(account.WithDraw(1));
        }
    }
}
