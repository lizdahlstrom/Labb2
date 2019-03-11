using Uppgift2.Datatypes;
using Uppgift2.Models.Customer;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class CustomerTests
    {
        [Fact]
        public static void Accounts_ShouldNotBeNull()
        {
            var customer = new Customer("john", "doe", "199001011234", new Address("street", "12345", "York"),
                "0703123456");

            Assert.NotNull(customer.Accounts);
        }
    }
}
