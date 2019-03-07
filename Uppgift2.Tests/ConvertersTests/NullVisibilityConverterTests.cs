using System.Globalization;
using System.Windows;
using Uppgift2.Converters;
using Uppgift2.Models.Accounts;
using Xunit;

namespace Uppgift2.Tests.ConvertersTests
{
    public class NullVisibilityConverterTests
    {
        [Fact]
        public static void Convert_ShouldReturnVisible_When_NotNull()
        {
            var converter = new NullVisibilityConverter();
            var customer = new SavingsAccount("12");

            Assert.Equal(expected: Visibility.Hidden, actual: converter.Convert(null, typeof(Visibility), null, new CultureInfo("sv-se")));
            Assert.Equal(expected: Visibility.Visible, actual: converter.Convert(customer, typeof(Visibility), null, new CultureInfo("sv-se")));
        }
    }
}
