using System;
using System.Text;

namespace Uppgift2.Static
{
    public enum AccountType
    {
        Checking,
        Savings,
        Retirement
    };

    public enum TransactionType
    {
        Withdrawal,
        Deposit
    };

    public static class Globals
    {
        public static string SaveFileName => "customers.bin";

        public static string ClearingNumber => "1234";

        public static string GenerateAccountId()
        {
            var r = new Random();

            string GetString(int length)
            {
                var sb = new StringBuilder();

                for (var i = 0; i < length; i++)
                {
                    sb.Append(r.Next(0, 10));
                }

                return sb.ToString();
            }

            return $"{Globals.ClearingNumber}-{GetString(4)} {GetString(4)} {GetString(2)}";
        }
    }
}