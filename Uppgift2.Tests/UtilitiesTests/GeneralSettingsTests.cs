using Uppgift2.Utilities;
using Xunit;

namespace Uppgift2.Tests.UtilitiesTests
{
    public class GeneralSettingsTests
    {
        [Fact]
        public static void CurrencyAbbreviation_ShouldNotBeNull()
        {
            Assert.NotNull(GeneralSettings.CurrencyAbbreviation);
        }
        [Fact]
        public static void SaveFileName_ShouldNotBeNull()
        {
            Assert.NotNull(GeneralSettings.SaveFileName);
        }

        [Fact]
        public static void ClearingNumber_ShouldNotBeNull()
        {
            Assert.NotNull(GeneralSettings.CurrencyAbbreviation);
        }
    }
}