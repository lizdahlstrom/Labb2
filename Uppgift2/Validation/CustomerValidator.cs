using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Uppgift2.Validation
{
    class CustomerValidator
    {
        private Customer customer;
        private List<string> Violations;

        public List<string> Validate(Customer customer)
        {
            this.customer = customer;

            var addressValidation
                = new List<string>(new AddressValidator().Validate(customer.Address));

            Violations = new List<string>();

            ValidateFirstName();
            ValidateLastName();
            ValidateSSN();
            ValidateCellphone();

            return Violations.Union(addressValidation).ToList();
        }

        private void ValidateFirstName()
        {
            ValidateName("FirstName", customer.FirstName);
        }

        private void ValidateLastName()
        {
            ValidateName("LastName", customer.LastName);
        }

        private void ValidateName(string propertyName, string name) // only non-letters, symbols etc are discriminated..
        {
            if (!name.All(char.IsLetter))
            {
                Violations.Add($"{propertyName} can only contain letters.");
            }
            else if (string.IsNullOrEmpty(name))
            {
                Violations.Add($"{propertyName} cannot be empty.");
            }
        }

        private void ValidateCellphone() // cellphone format: 07XXXXXXXX
        {
            if (string.IsNullOrEmpty(customer.Cellphone))
            {
                Violations.Add("Cellphone cannot be empty.");
            }
            else if (!new Regex(@"^0 *7[0236]*\d{4}]*\d{4}$").Match(customer.Cellphone).Success)
            {
                Violations.Add("Cellphone number must be in the format 07XXXXXXXX.");
            }
        }

        public void ValidateSSN() // SSN format: XXXXXXXX-XXXX
        {
            if (string.IsNullOrEmpty(customer.SocialSecurityNumber))
            {
                Violations.Add("SSN cannot be empty.");
            }
            else if (!new Regex(@"^\d{8}(?:\d{2})?[-\s]?\d{4}$").Match(customer.SocialSecurityNumber).Success)
            {
                Violations.Add("SSN must be in format XXXXXXXX-XXXX");
            }
        }
    }
}