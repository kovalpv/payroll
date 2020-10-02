namespace Payroll.EmployeeContext.Domain {
    public class Address {
        public Address (string country, string city, string street, string zip) {
            Country = country;
            City = city;
            Street = street;
            Zip = zip;
        }

        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string Zip { get; }

        public override string ToString () {
            return $"Address: ({Country}, {City}, {Street}, {Zip})";
        }
    }
}