using Uppgift2.Models.Customer;
using Uppgift2.Validation;
using Xunit;

namespace Uppgift2.Tests.ValidationTests
{
    public class AddressValidatorTests
    {
        [Theory]
        [InlineData("Hamnsgatan 3", "12345", "Gothenburg")]
        [InlineData("Kungsgatan 2", "32154", "Stockholm")]
        [InlineData("Brovägen 1", "84512", "Malmö")]
        public static void Validate_ShouldReturnEmptyList_When_NoErrors(string street, string zip, string city)
        {
            Assert.Empty(new AddressValidator().Validate(new Address(street, zip, city)));
        }

        [Theory]
        [InlineData("Hamnsgatan 3", "9999999999", "Gothenburg")]
        [InlineData("Kungsgatan 2", "32154", "135Stockholm")]
        [InlineData("", "84512", "Malmö")]
        public static void Validate_ShouldReturnList_OnError(string street, string zip, string city)
        {
            Assert.NotEmpty(new AddressValidator().Validate(new Address(street, zip, city)));
        }
    }
}
