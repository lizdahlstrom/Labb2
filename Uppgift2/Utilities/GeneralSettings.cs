using System;
using System.Configuration;

namespace Uppgift2.Utilities
{
    public static class GeneralSettings
    {
        // init with default settings
        public static string SaveFileName { get; set; } = "customers.bin";
        public static string ClearingNumber { get; set; } = "1234";
        public static string CurrencyAbbreviation { get; set; } = "$";

        static GeneralSettings()
        {
            ReadAllSettings();
        }

        private static void ReadAllSettings()
        {
            try
            {
                var settings = ConfigurationManager.AppSettings;
                if (!settings.HasKeys())
                    return;

                foreach (string key in settings)
                {
                    if (key.Equals("SaveFileName"))
                        SaveFileName = settings[key];
                    else if (key.Equals("ClearingNumber"))
                        ClearingNumber = settings[key];
                    else if (key.Equals("CurrencyAbbreviation"))
                        CurrencyAbbreviation = settings[key];
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
        }
    }
}
