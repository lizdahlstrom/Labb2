using Uppgift2.Datatypes;

namespace Uppgift2.Models.Accounts.Interfaces
{
    internal interface IAccountFactory
    {
        BankAccount CreateAccount(AccountType accountType, string id);
        CheckingAccount CreateCheckingAccountWithCredit(string id, double credit);
    }
}
