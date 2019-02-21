﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Uppgift2.Static;
using static Uppgift2.Static.Globals;

namespace Uppgift2.ViewModels
{
    public class BankViewModel : Screen
    {
        public AddNewCustomerViewModel AddNewCustomerViewModel { get; set; }
        public ManageAccountsViewModel ManageAccountsViewModel { get; set; }
        public BindableCollection<Customer> Customers { get; set; }

        public BankViewModel()
        {
            AddNewCustomerViewModel = new AddNewCustomerViewModel(this);
            ManageAccountsViewModel = new ManageAccountsViewModel(this);

            Load();
        }

        protected override void OnDeactivate(bool close) => Save();

        public void Load()
        {
            Customers = new BindableCollection<Customer>(File.Exists(SaveFileName)
                ? (FileOperations.Deserialize(SaveFileName) as List<Customer>)
                : new List<Customer>());
        }

        public void Save() => FileOperations.Serialize(Customers.ToList(), SaveFileName);
    }
}