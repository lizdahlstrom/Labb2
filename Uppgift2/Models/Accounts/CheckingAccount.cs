using System;
using Uppgift2.Accounts;
using Uppgift2.Static;

namespace Uppgift2
{
    [Serializable]
    public class CheckingAccount : BankAccount
    {
        private const double DefaultCredit = 25000;
        public override AccountType AccountType { get; } = AccountType.Checking;
        public double CreditLimit { get; private set; }
        public double CreditBalance => Balance >= 0 ? CreditLimit : CreditLimit - Math.Abs(Balance);

        public CheckingAccount(double creditLimit = DefaultCredit) => CreditLimit = creditLimit;

        public override void WithDraw(double amount)
        {
            var isCreditSufficient = Balance < 0 && CreditBalance >= amount;
            var isTotalBalanceSufficient = (Balance + CreditBalance) >= amount;

            if (!isTotalBalanceSufficient && !isCreditSufficient) return;

            Balance -= amount;
            AddTransaction(new Transaction(-amount));
        }
    }
}