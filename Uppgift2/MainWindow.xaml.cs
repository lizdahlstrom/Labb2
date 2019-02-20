using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Uppgift2.Static;

namespace Uppgift2
{
    partial class MainWindow : Window
    {
        private readonly Bank Bank;
        private Customer SelectedCustomer;

        public MainWindow()
        {
            InitializeComponent();
            Bank = new Bank();
            LoadComboboxSources();
            UpdateCustomerListBox();
        }

        private void Window_Closing(object sender, CancelEventArgs e) => Bank.Save();

        // --- Customer selection ---
        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer == null)
                return;

            Bank.DeleteCustomer(SelectedCustomer);
            SelectedCustomer = Bank.Customers.Any() ? Bank.Customers[0] : null;

            UpdateView();
        }

        // --- Add new Customer ---
        private void BtnAddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            string
                ssn = InputSSN.Text,
                fName = InputFname.Text,
                lname = InputLName.Text,
                phone = InputPhone.Text,
                zip = InputZip.Text,
                street = InputStreet.Text,
                city = InputCity.Text;

            var address = new Address(street, zip, city);
            var newCustomer = new Customer(fName, lname, ssn, address, phone);

            Bank.AddNewCustomer(newCustomer);

            UpdateView();
        }

        // --- Manage Accounts ---
        private void BtnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer == null)
                return;

            var accountType = (AccountType)comboBoxAddAccount.SelectedItem;

            if (!double.TryParse(tbSetAccountCredit.Text, out var credit))
            {
                if (!SelectedCustomer.OpenAccount(accountType))
                {
                    PopupHandler.DisplayError("Could not open account");
                };
            }
            else
            {
                if (!SelectedCustomer.OpenAccount(accountType, credit))
                {
                    PopupHandler.DisplayError("Could not open account");
                };
            }

            UpdateAccountListBox();
        }

        private void BtnCloseAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer == null)
                return;

            var selectedAccount
                = (BankAccount)listViewAccounts.SelectedItem;

            if (selectedAccount == null)
                return;

            SelectedCustomer.CloseAccount(selectedAccount);
            UpdateView();
        }

        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer == null)
                return;

            var account = ((BankAccount)listViewAccounts.SelectedItem);

            if (double.TryParse(tbTransactionAmount.Text, out var amount)
                && account != null)
            {
                var transactionType = (TransactionType)comboboxAddTransaction.SelectedItem;

                Bank.MakeTransaction(account, amount, transactionType);
            }

            UpdateAccountListBox();
        }

        // --- UI update methods ---
        private void LoadComboboxSources()
        {
            comboboxAddTransaction.ItemsSource = Enum.GetValues(typeof(TransactionType)) as TransactionType[];
            comboBoxAddAccount.ItemsSource = Enum.GetValues(typeof(AccountType)) as AccountType[];

            comboBoxAddAccount.SelectedItem = comboBoxAddAccount.Items[0];
            comboboxAddTransaction.SelectedItem = comboboxAddTransaction.Items[0];
        }

        private void ListboxCustomers_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (listboxCustomers.SelectedItem == null)
                return;

            SelectedCustomer = (Customer)listboxCustomers.SelectedItem;
            UpdateView();
        }

        private void ListViewAccounts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listViewAccounts.SelectedItem == null)
                return;

            UpdateTransactionListBox();
        }

        private void ComboBoxAddAccount_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tbSetAccountCredit == null)
                return;

            tbSetAccountCredit.Clear();
            tbSetAccountCredit.Visibility
                = comboBoxAddAccount.SelectedItem.Equals(AccountType.Checking) ? Visibility.Visible : Visibility.Hidden;
        }

        private void UpdateView()
        {
            UpdateCustomerListBox();
            UpdateTransactionListBox();
            UpdateAccountListBox();
            DisplayActiveCustomer();
        }

        private void UpdateCustomerListBox()
        {
            listboxCustomers.ItemsSource = null;
            if (Bank.Customers != null)
            {
                listboxCustomers.ItemsSource = Bank.Customers;
            }
        }

        private void UpdateTransactionListBox()
        {
            listboxTransactions.ItemsSource = null;
            var selectedAccount = (BankAccount)listViewAccounts.SelectedItem;

            if (selectedAccount != null)
            {
                listboxTransactions.ItemsSource
                    = selectedAccount.Transactions.OrderByDescending(transaction => transaction.Date);
            }
        }

        private void UpdateAccountListBox()
        {
            if (SelectedCustomer == null)
                return;

            var selectedIndex = listViewAccounts.SelectedIndex == -1 ? 0 : listViewAccounts.SelectedIndex;
            listViewAccounts.ItemsSource = null;
            listViewAccounts.ItemsSource = SelectedCustomer.Accounts;
            listViewAccounts.SelectedIndex = selectedIndex;

        }

        private void DisplayActiveCustomer()
        {
            if (SelectedCustomer == null)
            {
                txtSelectedCustomerName.Text = "";
                txtSelectedCustomerSSN.Text = "";
                txtSelectedCustomerStreet.Text = "";
                txtSelectedCustomerZipCode.Text = "";
                txtSelectedCustomerCity.Text = "";
                txtSelectedCustomerCellphone.Text = "";
            }
            else
            {
                txtSelectedCustomerName.Text = SelectedCustomer.FullName;
                txtSelectedCustomerSSN.Text = SelectedCustomer.SocialSecurityNumber;
                txtSelectedCustomerStreet.Text = SelectedCustomer.Address.Street;
                txtSelectedCustomerZipCode.Text = SelectedCustomer.Address.ZipCode;
                txtSelectedCustomerCity.Text = SelectedCustomer.Address.City;
                txtSelectedCustomerCellphone.Text = SelectedCustomer.Cellphone;
            }
        }

    }
}
