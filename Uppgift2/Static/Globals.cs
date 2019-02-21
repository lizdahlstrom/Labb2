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
    }
}