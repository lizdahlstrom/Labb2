using Uppgift2.Datatypes;
using Uppgift2.Models.Accounts;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class AccountFactoryTests
    {
        [Theory]
        [InlineData(AccountType.Checking)]
        [InlineData(AccountType.Savings)]
        [InlineData(AccountType.Retirement)]
        public static void CreateAccount_ShouldReturnAccountOfSameType(AccountType accountType)
        {
            const string id = "1234";
            var accountFactory = new AccountFactory();
            var expected = accountType;

            var actual = accountFactory.CreateAccount(accountType, id).AccountType;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(900)]
        [InlineData(400)]
        public static void CreateCheckingAccount_ShouldReturnAccountWithSetCredit(double credit)
        {
            const string id = "1234";
            var accountFactory = new AccountFactory();
            var account = accountFactory.CreateCheckingAccountWithCredit(id, credit);

            var actualCredit = account.CreditBalance;

            Assert.Equal(credit, actualCredit);
        }
    }
}
