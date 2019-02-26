using Caliburn.Micro;
using System.Linq;
using Uppgift2.Static;
using static Uppgift2.Static.PopupHandler;

namespace Uppgift2.ViewModels
{
    public class AddNewCustomerViewModel : Screen
    {
        private string _firstName = "";
        private string _lastName = "";
        private string _ssn = "";
        private string _phoneNumber = "";
        private string _zip = "";
        private string _street = "";
        private string _city = "";
        private BankViewModel BankViewModel { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string SSN
        {
            get => _ssn;
            set
            {
                _ssn = value;
                NotifyOfPropertyChange(() => SSN);
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        public string Zip
        {
            get => _zip;
            set
            {
                _zip = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }

        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public AddNewCustomerViewModel(BankViewModel bankViewModel)
        {
            BankViewModel = bankViewModel;
        }

        public bool CanAddNewCustomer(string firstName, string lastName, string ssn,
            string phoneNumber, string zip, string street, string city)
        {
            return !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName)
                                                         && !string.IsNullOrWhiteSpace(ssn) &&
                                                         !string.IsNullOrWhiteSpace(phoneNumber)
                                                         && !string.IsNullOrWhiteSpace(zip) &&
                                                         !string.IsNullOrWhiteSpace(street)
                                                         && !string.IsNullOrWhiteSpace(city);
        }

        public void AddNewCustomer(string firstName, string lastName, string ssn, string phoneNumber, string zip,
            string street, string city)
        {
            var newCustomer = new Customer(firstName, lastName, ssn,
                (new Address(street, zip, city)), phoneNumber);

            if (!IsCustomerValid(newCustomer)) return;

            BankViewModel.Customers.Add(newCustomer);

            DisplaySuccess("Added customer",
                $"{newCustomer.FirstName} {newCustomer.LastName} has been added successfully.");

            ClearForm();
        }

        private bool IsCustomerValid(Customer customer)
        {
            var validationErrors = new CustomerValidator().Validate(customer);

            if (validationErrors.Count > 0)
            {
                DisplayValidationViolations(validationErrors);
                return false;
            }

            if (BankViewModel.Customers.Any(c => c.SocialSecurityNumber.Equals(customer.SocialSecurityNumber)))
            {
                DisplayError($"Customer with same SSN already exists.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            FirstName = "";
            LastName = "";
            SSN = "";
            PhoneNumber = "";
            Zip = "";
            Street = "";
            City = "";
        }
    }
}