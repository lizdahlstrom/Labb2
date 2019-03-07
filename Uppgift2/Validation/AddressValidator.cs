using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Uppgift2.Models.Customer;

namespace Uppgift2.Validation
{
    public class AddressValidator
    {
        private Address address;
        private List<string> invalidMessages;

        public List<string> Validate(Address address)
        {
            this.address = address;

            invalidMessages = new List<string>();

            ValidateCity();
            ValidateStreet();
            ValidateZipCode();

            return invalidMessages;
        }

        private void ValidateCity()
        {
            if (!address.City.All(char.IsLetter))
            {
                invalidMessages.Add("City name can only contain letters.");
            }
            else if (string.IsNullOrEmpty(address.City))
            {
                invalidMessages.Add("City name cannot be empty.");
            }
        }

        private void ValidateStreet()
        {
            if (string.IsNullOrEmpty(address.Street))
            {
                invalidMessages.Add("Street name cannot be empty.");
            }
        }

        private void ValidateZipCode() // zip format: XXXXX
        {
            if (string.IsNullOrEmpty(address.ZipCode))
            {
                invalidMessages.Add("Zip code cannot be empty.");
            }
            else if (!new Regex(@"^[0-9]\d{4}$").Match(address.ZipCode).Success)
            {
                invalidMessages.Add("Zip code is in invalid format.");
            }
        }
    }
}