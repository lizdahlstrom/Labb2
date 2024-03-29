﻿using Uppgift2.Models.Accounts;
using Xunit;

namespace Uppgift2.Tests.ModelsTests
{
    public class CheckingAccountTests
    {
        [Fact]
        public static void Withdraw_ShouldReturnTrue_When_FundsAreSufficient()
        {
            var account = new CheckingAccount("123");
            account.Deposit(2);

            Assert.True(account.WithDraw(1));
        }

        [Fact]
        public static void Withdraw_ShouldReturnFalse_When_FundsAreNotSufficient()
        {
            var account = new CheckingAccount("123",0);

            Assert.False(account.WithDraw(1));
        }

        [Fact]
        public static void Withdraw_ShouldReturnTrue_When_CreditIsSufficient()
        {
            var account = new CheckingAccount("123", 1);

            Assert.True(account.WithDraw(1));
        }

        [Fact]
        public static void IsCreditSufficientTest()
        {
            var account = new CheckingAccount("123", 3);

            Assert.True(account.IsCreditSufficient(1));
            Assert.False(account.IsCreditSufficient(4));
        }

        [Fact]
        public static void IsTotalBalanceSufficient_ShouldReturnFalse()
        {
            var account = new CheckingAccount("123",0);

            Assert.False(account.IsTotalBalanceSufficient(2));
        }

        [Fact]
        public static void IsTotalBalanceSufficient_ShouldReturnTrue()
        {
            var account = new CheckingAccount("123");
            account.Deposit(3);

            Assert.True(account.IsTotalBalanceSufficient(2));
        }
    }
}
