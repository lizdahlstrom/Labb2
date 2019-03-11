using System;
using System.Collections.Generic;
using Uppgift2.Datatypes;
using Uppgift2.Models.Accounts;

namespace Uppgift2.Models.Customer
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

        public void OpenAccount(BankAccount account) => Accounts.Add(account);

        public void CloseAccount(BankAccount account) => Accounts.Remove(account);
    }
}