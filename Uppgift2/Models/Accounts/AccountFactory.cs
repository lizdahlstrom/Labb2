using System;
using System.ComponentModel;
using Uppgift2.Datatypes;


namespace Uppgift2.Models.Accounts
{
    public class AccountFactory
    {
        /// <summary>
        /// Creates account based on accountType
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="id"></param>
        /// <exception>Will throw InvalidEnumArgumentException if AccountType is invalid</exception>
        public BankAccount CreateAccount(AccountType accountType, string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException();

            switch (accountType)
            {
                case AccountType.Checking:
                    return new CheckingAccount(id);
                case AccountType.Retirement:
                    return new RetirementAccount(id);
                case AccountType.Savings:
                    return new SavingsAccount(id);
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public CheckingAccount CreateCheckingAccountWithCredit(string id, double credit)
        {
            return new CheckingAccount(id, credit);
        }
    }
}
