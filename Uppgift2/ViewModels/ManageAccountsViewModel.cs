﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uppgift2.Datatypes;
using Uppgift2.Models.Accounts;
using Uppgift2.Models.Customer;
using static Uppgift2.Utilities.GeneralSettings;

namespace Uppgift2.ViewModels
{
    public class ManageAccountsViewModel : Screen
    {
        private Customer _selectedCustomer;
        private BindableCollection<BankAccount> _accounts;
        private BankAccount _selectedAccount;
        private double _accountCredit;
        private double _transactionAmount;
        private BindableCollection<Transaction> _transactions;
        private AccountType _selectedAccountType;

        public BankViewModel BankViewModel { get; }
        public IReadOnlyList<AccountType> AccountType { get; }
        public IReadOnlyList<TransactionType> TransactionType { get; }
        public TransactionType SelectedTransactionType { get; set; } = Datatypes.TransactionType.Deposit;

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                NotifyOfPropertyChange(() => SelectedCustomer);
                NotifyOfPropertyChange(() => CanAddAccount);
                Accounts = SelectedCustomer != null
                    ? new BindableCollection<BankAccount>(SelectedCustomer.Accounts)
                    : new BindableCollection<BankAccount>();
            }
        }

        public BindableCollection<BankAccount> Accounts
        {
            get => _accounts ?? (_accounts = new BindableCollection<BankAccount>());
            set
            {
                
                _accounts = value;
                NotifyOfPropertyChange(() => Accounts);
                NotifyOfPropertyChange(() => CanMakeTransaction);
            }
        }

        public BankAccount SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                NotifyOfPropertyChange(() => SelectedAccount);
                NotifyOfPropertyChange(() => CanCloseAccount);
                Transactions = SelectedAccount != null
                    ? new BindableCollection<Transaction>(SelectedAccount.Transactions)
                    : new BindableCollection<Transaction>();
            }
        }

        public double AccountCredit
        {
            get => _accountCredit;
            set
            {
                _accountCredit = value;
                NotifyOfPropertyChange(() => AccountCredit);
                NotifyOfPropertyChange(() => CanAddAccount);
            }
        }

        public double TransactionAmount
        {
            get => _transactionAmount;
            set
            {
                _transactionAmount = value;
                NotifyOfPropertyChange(() => TransactionAmount);
                NotifyOfPropertyChange(() => CanMakeTransaction);
            }
        }

        public BindableCollection<Transaction> Transactions
        {
            get
            {
                if (_transactions == null) return _transactions = new BindableCollection<Transaction>();
                return new BindableCollection<Transaction>(_transactions.OrderByDescending(t => t.Date));
            }
            set
            {
                _transactions = value;
                NotifyOfPropertyChange(() => Transactions);
                NotifyOfPropertyChange(() => SelectedAccount);
            }
        }

        public AccountType SelectedAccountType
        {
            get => _selectedAccountType;
            set
            {
                _selectedAccountType = value;
                NotifyOfPropertyChange(() => SelectedAccountType);
                NotifyOfPropertyChange(() => CanAddAccount);
            }
        }

        public ManageAccountsViewModel(BankViewModel bankViewModel)
        {
            BankViewModel = bankViewModel;

            AccountType = Enum.GetValues(typeof(AccountType)) as AccountType[];
            TransactionType = Enum.GetValues(typeof(TransactionType)) as TransactionType[];
            SelectedAccountType = Datatypes.AccountType.Checking;
        }

        public bool CanAddAccount => SelectedCustomer != null;

        public void AddAccount()
        {
            var accountId = GetUniqueAccountId();
            var accountFactory = new AccountFactory();

            SelectedCustomer.OpenAccount(AccountCredit > 0
                ? accountFactory.CreateCheckingAccountWithCredit(accountId, AccountCredit)
                : accountFactory.CreateAccount(SelectedAccountType, accountId));

            AccountCredit = 0;
            Accounts = new BindableCollection<BankAccount>(SelectedCustomer.Accounts);
        }

        public bool CanCloseAccount => SelectedCustomer != null && SelectedAccount != null;

        public void CloseAccount()
        {
            SelectedCustomer.CloseAccount(SelectedAccount);
            Accounts = new BindableCollection<BankAccount>(SelectedCustomer.Accounts);
        }

        public bool CanMakeTransaction => TransactionAmount > 0 && SelectedAccount != null;

        public void MakeTransaction()
        {
            switch (SelectedTransactionType)
            {
                case Datatypes.TransactionType.Withdrawal:
                    SelectedAccount.WithDraw(TransactionAmount);
                    break;
                case Datatypes.TransactionType.Deposit:
                    SelectedAccount.Deposit(TransactionAmount);
                    break;
            }

            TransactionAmount = 0;
            Accounts = new BindableCollection<BankAccount>(SelectedCustomer.Accounts);
            Transactions = new BindableCollection<Transaction>(SelectedAccount.Transactions);
        }

        public void RemoveCustomer()
        {
            BankViewModel.Customers.Remove(SelectedCustomer);
            NotifyOfPropertyChange(() => SelectedCustomer);
        }

        private string GetUniqueAccountId()
        {
            string accountId;

            do
            {
                accountId = GenerateAccountId();
            } while (IsIdExistent());

            bool IsIdExistent()
            {
                return BankViewModel.Customers.SelectMany(c => c.Accounts).Any(a => a.AccountNumber == accountId);
            }

            return accountId;
        }

        private static string GenerateAccountId()
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

            return $"{ClearingNumber}-{GetString(4)} {GetString(4)} {GetString(2)}";
        }
    }
}