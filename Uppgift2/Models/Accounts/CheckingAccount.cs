using System;
using Uppgift2.Datatypes;

namespace Uppgift2.Models.Accounts
{
    [Serializable]
    public class CheckingAccount : BankAccount
    {
        private const double DefaultCredit = 25000;
        public override AccountType AccountType { get; } = AccountType.Checking;
        public double CreditLimit { get; private set; }
        public double CreditBalance => Balance >= 0 ? CreditLimit : CreditLimit - Math.Abs(Balance);

        public CheckingAccount(string id, double creditLimit = DefaultCredit) : base(id) => CreditLimit = creditLimit;

        public override bool WithDraw(double amount)
        {
            if (!IsTotalBalanceSufficient(amount) && !IsCreditSufficient(amount)) return false;

            Balance -= amount;
            AddTransaction(new Transaction(-amount));
            return true;
        }

        public bool IsCreditSufficient(double amountToWithdraw)
        {
            return Balance <= 0 && CreditBalance >= amountToWithdraw;
        }

        public bool IsTotalBalanceSufficient(double amountToWithdraw)
        {
            return (Balance + CreditBalance) >= amountToWithdraw;
        }
    }
}