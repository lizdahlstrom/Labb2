using System;

namespace Uppgift2
{
    [Serializable]
    public class Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public string FullAddress => $"{Street} {ZipCode} {City}";

        public Address(string street, string zipCode, string city)
        {
            Street = street;
            ZipCode = zipCode;
            City = city;
        }
    }
}