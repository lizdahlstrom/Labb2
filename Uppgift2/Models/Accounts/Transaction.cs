﻿using System;
using Uppgift2.Datatypes;
using Uppgift2.Utilities;

namespace Uppgift2.Models.Accounts
{
    [Serializable]
    public class Transaction
    {
        public DateTime Date { get; } = DateTime.Now;
        public double Amount { get; }
        public TransactionType TransactionType { get; }
        public double Fee { get; }

        public Transaction(double amount, double fee = 0)
        {
            TransactionType = amount > 0 ? TransactionType.Deposit : TransactionType.Withdrawal;
            Amount = amount;
            Fee = fee;
        }

        public override string ToString()
        {
            var str = $"{Date:yyyy-MM-dd}      {Amount}{GeneralSettings.CurrencyAbbreviation} ({TransactionType})";

            return Fee <= 0 ? str : $"{str}   (Fee paid: {Fee}{GeneralSettings.CurrencyAbbreviation})";
        }
    }
}