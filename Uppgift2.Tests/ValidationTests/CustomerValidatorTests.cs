using Uppgift2.Models.Customer;
using Uppgift2.Validation;
using Xunit;

namespace Uppgift2.Tests.ValidationTests
{
    public class CustomerValidatorTests
    {
        [Theory]
        [InlineData("John", "Doe", "199001011234", "0706185422")]
        [InlineData("Jane", "Doe", "197806184321", "0733684957")]
        [InlineData("Bill", "Doe", "195708039875", "0733971532")]

        public static void Validate_ShouldReturnEmptyList_When_NoErrors(string firstName, string lastName, string ssn, string phone)
        {
            var customer = new Customer(firstName, lastName, ssn, new Address("street", "12345", "York"),
                phone);

            Assert.Empty(new CustomerValidator().Validate(customer));
        }

        [Theory]
        [InlineData("John", "Doe", "199001011234", "99999999")]
        [InlineData("Jane", "Doe", "2020", "0733684957")]
        [InlineData("123", "Doe", "195708039875", "0733971532")]
        public static void Validate_ShouldReturnList_OnError(string firstName, string lastName, string ssn, string phone)
        {
            var customer = new Customer(firstName, lastName, ssn, new Address("street", "12345", "York"),
                phone);

            Assert.NotEmpty(new CustomerValidator().Validate(customer));
        }

        [Theory]
        [InlineData(null, "Doe", "199001011234", "99999999")]
        [InlineData("John", null, "199001011234", "99999999")]
        [InlineData("Jane", "Doe", "2020", null)]
        [InlineData("123", "Doe", null, "0733971532")]
        public static void Validate_ShouldReturnList_When_Null(string firstName, string lastName, string ssn, string phone)
        {
            var customer = new Customer(firstName, lastName, ssn, new Address("street", "12345", "York"),
                phone);

            Assert.NotEmpty(new CustomerValidator().Validate(customer));
        }
    }
}
