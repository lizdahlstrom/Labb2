using System.Collections.Generic;
using System.Windows;

namespace Uppgift2.Static
{
    static class MessageBoxHandler
    {

        public static void DisplayValidationViolations(List<string> violations)
        {
            MessageBox.Show(GenerateMessageString(violations), "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void DisplayError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static string GenerateMessageString(List<string> messages)
        {
            var messageString = "";

            messages.ForEach(message => messageString += $"{message}\n");

            return messageString;
        }

    }
}
