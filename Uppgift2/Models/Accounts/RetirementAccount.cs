using System;
using Uppgift2.Datatypes;

namespace Uppgift2.Models.Accounts
{
    [Serializable]
    public class RetirementAccount : BankAccount
    {
        private static readonly double interest = 3.0;
        private readonly double withdrawalFeePercentage = 0.1;
        public override AccountType AccountType { get; } = AccountType.Retirement;
        public double Interest { get; } = interest;

        public RetirementAccount(string id) : base(id) { }

        public override bool WithDraw(double amount)
        {
            var fee = CalculateFee(amount);
            var amountWithFee = amount + fee;

            if (!(Balance - amountWithFee >= 0)) return false;
            Balance -= amountWithFee;
            AddTransaction(new Transaction(-amount, fee));
            return true;
        }

        private double CalculateFee(double amount) => amount * withdrawalFeePercentage;
    }
}