using System.Collections.Generic;

namespace Uppgift2.Static
{
    static class DummyData
    {
        public static List<Customer> customers { get; }
            = new List<Customer>
            {
                new Customer("Viki", "Staniford", "19950219-1213", new Address("Union Street 1", "12345", "Yongheshi"),
                    "0709618630"),
                new Customer("Cameron", "Zeplin", "19870819-5432", new Address("Ruskin Road 2", "23456", "Gävle"),
                    "0709618630"),
                new Customer("Maryann", "Tomasz", "19580529-5757", new Address("East Street 3", "34567", "Topeka"),
                    "0709618630"),
                new Customer("Gusty", "McKelvey", "19610221-4242", new Address("Kinsman Avenue 4", "45678", "Kumai"),
                    "0709618630"),
                new Customer("Dirk", "Ferneley", "19631101-8451", new Address("Burning Wood 5", "56789", "Santa Cruz"),
                    "0733827162")
            };
    }
}