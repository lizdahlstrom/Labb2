﻿using System;
using Uppgift2.Datatypes;

namespace Uppgift2.Models.Accounts
{
    [Serializable]
    public class SavingsAccount : BankAccount
    {
        private static readonly double interest = 0.5;
        public override AccountType AccountType { get; } = AccountType.Savings;
        public double Interest { get; } = interest;
        public SavingsAccount(string id) : base(id) { }
    }
}