using System.Collections.Generic;
using System.Windows;

namespace Uppgift2.Static
{
    static class PopupHandler
    {

        public static void DisplayValidationViolations(List<string> violations)
        {
            MessageBox.Show(GenerateMessageString(violations), "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void DisplayError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void DisplaySuccess(string caption, string msg)
        {
            MessageBox.Show(msg, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static string GenerateMessageString(List<string> messages)
        {
            var messageString = "";

            messages.ForEach(message => messageString += $"{message}\n");

            return messageString;
        }


    }
}
