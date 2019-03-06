using System;
using System.Collections.Generic;
using Uppgift2.Datatypes;
using Uppgift2.Models.Accounts;
using Uppgift2.Static;

namespace Uppgift2
{
    [Serializable]
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; }
        public Address Address { get; set; }
        public string Cellphone { get; set; }
        public List<BankAccount> Accounts { get; } = new List<BankAccount>();
        public string FullName => $"{FirstName} {LastName}";

        public Customer(string firstName, string lastName, string socialsecurity, Address address, string cellphone)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Cellphone = cellphone;
            SocialSecurityNumber = socialsecurity;
        }

        public bool OpenAccount(AccountType accountType, string id)
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    Accounts.Add(new CheckingAccount(id));
                    return true;
                case AccountType.Savings:
                    Accounts.Add(new SavingsAccount(id));
                    return true;
                case AccountType.Retirement:
                    Accounts.Add(new RetirementAccount(id));
                    return true;
                default:
                    return false;
            }
        }

        public bool OpenAccount(AccountType accountType, double credit, string id)
        {
            if (!accountType.Equals(AccountType.Checking))
                return false;

            Accounts.Add(new CheckingAccount(id, credit));
            return true;
        }

        public void CloseAccount(BankAccount account) => Accounts.Remove(account);
    }
}