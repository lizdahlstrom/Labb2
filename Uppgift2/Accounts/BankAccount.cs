using System;
using System.Collections.Generic;
using System.Text;
using Uppgift2.Accounts;
using Uppgift2.Static;

namespace Uppgift2
{
    [Serializable]
    public abstract class BankAccount
    {
        public abstract AccountType AccountType { get; }
        public string AccountNumber { get; }
        public double Balance { get; set; } = 0;
        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public BankAccount() => AccountNumber = GenerateId();

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

        private string GenerateId()
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
