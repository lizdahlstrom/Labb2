using System.Collections.Generic;
using System.IO;
using System.Linq;
using Uppgift2.Static;
using static Uppgift2.Static.Globals;
using static Uppgift2.Static.MessageBoxHandler;

namespace Uppgift2
{
    public class Bank
    {
        public List<Customer> Customers { get; private set; }

        public Bank() => Load();

        public void AddNewCustomer(Customer customer)
        {
            var validationViolations = new CustomerValidator().Validate(customer);

            if (validationViolations.Any())
            {
                DisplayValidationViolations(validationViolations);
            }
            else if (Customers.Any(c => c.SocialSecurityNumber.Equals(customer.SocialSecurityNumber)))
            {
                DisplayError($"Customer with same SSN already exists.");
            }
            else
            {
                Customers.Add(customer);
            }
        }

        public void DeleteCustomer(Customer customer)
            => Customers.Remove(customer);

        public void MakeTransaction(BankAccount account, double amount, TransactionType transactionType)
        {
            if (transactionType is TransactionType.Withdrawal)
                account.WithDraw(amount);
            else if (transactionType is TransactionType.Deposit) account.Deposit(amount);
        }

        public void Load()
        {
            Customers = File.Exists(SaveFileName)
                ? (FileOperations.Deserialize(SaveFileName) as List<Customer>)
                : new List<Customer>();
        }

        public void Save() => FileOperations.Serialize(Customers, SaveFileName);
    }
}
