using System.Globalization;
using System.Windows;
using Uppgift2.Converters;
using Uppgift2.Datatypes;
using Xunit;

namespace Uppgift2.Tests.ConvertersTests
{
    public class CreditVisibilityConverterTests
    {
        [Fact]
        public static void Convert_ShouldReturnVisible_When_AccountTypeIsChecking()
        {
            var converter = new CreditVisibilityConverter();
            
            Assert.Equal(expected: Visibility.Visible, actual: converter.Convert(AccountType.Checking, typeof(Visibility), null, new CultureInfo("sv-se")));
        }

        [Fact]
        public static void Convert_ShouldReturnHidden_When_AccountTypeIsNotChecking()
        {
            var converter = new CreditVisibilityConverter();
            
            Assert.Equal(expected: Visibility.Hidden, actual: converter.Convert(AccountType.Retirement, typeof(Visibility), null, new CultureInfo("sv-se")));
            Assert.Equal(expected: Visibility.Hidden, actual: converter.Convert(AccountType.Savings, typeof(Visibility), null, new CultureInfo("sv-se")));
            Assert.Equal(expected: Visibility.Hidden, actual: converter.Convert(null, typeof(Visibility), null, new CultureInfo("sv-se")));
        }
    }
}
