using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private AccountType _selectedAccountType;

        public BankViewModel BankViewModel { get; }
        public IReadOnlyList<AccountType> AccountType { get; }
        public IReadOnlyList<TransactionType> TransactionType { get; }
        public TransactionType SelectedTransactionType { get; set; } = Static.TransactionType.Deposit;

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
            get => _accounts;
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
            get => new BindableCollection<Transaction>(_transactions.OrderByDescending(t => t.Date));
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
            SelectedAccountType = Static.AccountType.Checking;

            Accounts = new BindableCollection<BankAccount>();
            Transactions = new BindableCollection<Transaction>();
        }

        public bool CanAddAccount => SelectedCustomer != null;

        public void AddAccount()
        {
            var accountId = GetUniqueAccountId();

            if (AccountCredit > 0)
            {
                SelectedCustomer.OpenAccount(SelectedAccountType, AccountCredit, accountId);
            }
            else
            {
                SelectedCustomer.OpenAccount(SelectedAccountType, accountId);
            }

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
                case Static.TransactionType.Withdrawal:
                    SelectedAccount.WithDraw(TransactionAmount);
                    break;
                case Static.TransactionType.Deposit:
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
                accountId = Globals.GenerateAccountId();
            } while (IsIdExistent());

            bool IsIdExistent()
            {
                return BankViewModel.Customers.SelectMany(c => c.Accounts).Any(a => a.AccountNumber == accountId);
            }

            return accountId;
        }
    }
}