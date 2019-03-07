using Uppgift2.Models.Accounts;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class RetirementAccountTests
    {
        [Theory]
        [InlineData(10, 9)]
        [InlineData(10, 4)]
        [InlineData(1000.1, 0.1)]
        public static void Withdraw_ShouldReturnTrue_When_FundsAreSufficient(double deposit, double withdraw)
        {
            var account = new RetirementAccount("123");
            account.Deposit(deposit);

            Assert.True(account.WithDraw(withdraw));
        }

        [Fact]
        public static void Withdraw_ShouldReturnFalse_When_FundsAreNotSufficient()
        {
            var account = new RetirementAccount("123");

            Assert.False(account.WithDraw(1));
        }
    }
}
