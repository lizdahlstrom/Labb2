using Uppgift2.Datatypes;
using Uppgift2.Models.Customer;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class CustomerTests
    {
        [Theory]
        [InlineData(AccountType.Checking)]
        [InlineData(AccountType.Savings)]
        [InlineData(AccountType.Retirement)]
        public static void OpenAccount_ShouldReturnTrue_When_AccountTypeExists(AccountType type)
        {
            var customer = new Customer("john", "doe", "199001011234", new Address("street", "12345", "York"),
                "0703123456");

            Assert.True(customer.OpenAccount(type, "133"));
        }

        [Fact]
        public static void Accounts_ShouldNotBeNull()
        {
            var customer = new Customer("john", "doe", "199001011234", new Address("street", "12345", "York"),
                "0703123456");

            Assert.NotNull(customer.Accounts);
        }
    }
}
