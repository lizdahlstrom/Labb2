using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift2.Datatypes;
using Uppgift2.Models.Accounts.Interfaces;

namespace Uppgift2.Models.Accounts
{
    public class AccountFactory : IAccountFactory
    {
        /// <summary>
        /// Will throw InvalidEnumArgumentException if AccountType is invalid
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="id"></param>
        public BankAccount CreateAccount(AccountType accountType, string id)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentException();

            switch (accountType)
            {
                case (AccountType.Checking):
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
