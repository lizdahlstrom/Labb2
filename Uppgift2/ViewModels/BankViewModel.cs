using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Uppgift2.Static;

namespace Uppgift2.ViewModels
{
    public class BankViewModel : Screen
    {
        public AddNewCustomerViewModel AddNewCustomerViewModel { get; set; }
        public ManageAccountsViewModel ManageAccountsViewModel { get; set; }
        public BindableCollection<Customer> Customers { get; set; } = new BindableCollection<Customer>(DummyData.customers);
        
        public BankViewModel()
        {
            AddNewCustomerViewModel = new AddNewCustomerViewModel(this);
            ManageAccountsViewModel = new ManageAccountsViewModel(this);
        }

    }
}
