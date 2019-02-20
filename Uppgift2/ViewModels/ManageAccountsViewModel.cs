using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Uppgift2.Accounts;
using Uppgift2.Static;

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
        private AccountType _selectedAccountType = Static.AccountType.Checking;

        public BankViewModel BankViewModel { get; }
        public IReadOnlyList<AccountType> AccountType { get; }
        public IReadOnlyList<TransactionType> TransactionType { get; set; }

        public AccountType SelectedAccountType
        {
            get => _selectedAccountType;
            set { _selectedAccountType = value; NotifyOfPropertyChange(() => SelectedAccountType); }
        }

        public TransactionType SelectedTransactionType { get; set; } = Static.TransactionType.Deposit;

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                NotifyOfPropertyChange(() => SelectedCustomer);
                Accounts = new BindableCollection<BankAccount>(SelectedCustomer.Accounts);
            }
        }

        public BindableCollection<BankAccount> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value; NotifyOfPropertyChange(() => Accounts);
            }
        }

        public BankAccount SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                NotifyOfPropertyChange(() => SelectedAccount);
            }
        }

        public double AccountCredit
        {
            get => _accountCredit;
            set { _accountCredit = value; NotifyOfPropertyChange(() => AccountCredit); }
        }

        public double TransactionAmount
        {
            get => _transactionAmount;
            set { _transactionAmount = value; NotifyOfPropertyChange(() => TransactionAmount); }
        }

        public BindableCollection<Transaction> Transactions
        {
            get => _transactions;
            set { _transactions = value; NotifyOfPropertyChange(() => Transactions); }
        }

        public ManageAccountsViewModel(BankViewModel bankViewModel)
        {
            BankViewModel = bankViewModel;

            AccountType = Enum.GetValues(typeof(AccountType)) as AccountType[];
            TransactionType = Enum.GetValues(typeof(TransactionType)) as TransactionType[];

            Accounts = SelectedCustomer != null
                ? new BindableCollection<BankAccount>(SelectedCustomer.Accounts)
                : new BindableCollection<BankAccount>();
            Transactions = SelectedAccount != null
                ? new BindableCollection<Transaction>(SelectedAccount.Transactions)
                : new BindableCollection<Transaction>();
        }

        public bool CanAddAccount(AccountType accountType, double accountCredit)
        {
            return SelectedCustomer != null;
        }

        public void AddAccount(AccountType accountType, double accountCredit)
        {
            if (AccountCredit > 0)
            {
                SelectedCustomer.OpenAccount(accountType, AccountCredit);
            }
            else
            {
                SelectedCustomer.OpenAccount(accountType);
            }

            Accounts = new BindableCollection<BankAccount>(SelectedCustomer.Accounts);
        }

        public bool CanCloseAccount()
        {
            return SelectedCustomer != null && SelectedAccount != null;
        }

        public void CloseAccount()
        {
            SelectedCustomer.CloseAccount(SelectedAccount);
        }

        public bool CanMakeTransaction()
        {
            if (TransactionAmount > 0 && SelectedAccount != null)
                return true;
            return false;
        }


        public void MakeTransaction()
        {
            if (SelectedTransactionType is Static.TransactionType.Withdrawal)
                SelectedAccount.WithDraw(TransactionAmount);
            else if (SelectedTransactionType is Static.TransactionType.Deposit)
                SelectedAccount.Deposit(TransactionAmount);
        }

        public void RemoveCustomer()
        {
            Debug.WriteLine($"deleting {SelectedCustomer}");
            BankViewModel.Customers.Remove(SelectedCustomer);
            NotifyOfPropertyChange(() => SelectedCustomer);
        }




    }
}
