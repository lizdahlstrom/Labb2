using System;
using System.Collections.Generic;
using Uppgift2.Datatypes;

namespace Uppgift2.Models.Accounts
{
    [Serializable]
    public abstract class BankAccount
    {
        public abstract AccountType AccountType { get; }
        public string AccountNumber { get; }
        public double Balance { get; set; } = 0;
        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public BankAccount(string id) => AccountNumber = id;

        public virtual void Deposit(double amount)
        {
            Balance += amount;
            AddTransaction(new Transaction(amount));
        }

        public virtual void WithDraw(double amount)
        {
            if (!(Balance - amount >= 0)) return;
            Balance -= amount;
            AddTransaction(new Transaction(-amount));
        }

        protected void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
    }
}