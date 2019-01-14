using System;
using System.Collections.Generic;
using System.Text;

namespace DomainWithEF.Domain.Customers
{
    public class Address
    {
        public Customer Customer { get; private set; }
        public string HouseNumber { get; private set; }
        public string Street { get; private set; }
        public string Block { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public bool IsDefaultAddress { get; private set; }
        public Address(Customer customer, string houseNumber, string street, string block, string city, string country)
        {
            if (customer is null)
                throw new ArgumentNullException("");

            this.Customer = customer;
            this.HouseNumber = houseNumber;
            this.Street = street;
            this.Block = block;
            this.City = city;
            this.Country = country;
        }

        public void MakeAsDefault()
        {
            if (!this.IsDefaultAddress)
            {
                foreach (var address in this.Customer.Addresses)
                        address.IsDefaultAddress = false;

                this.IsDefaultAddress = true;
            }
        }

        public override string ToString()
        {
            return $"Address: {HouseNumber}, {this.Street}, {this.Block}, {this.City}, {this.Country} {(this.IsDefaultAddress == true ? "- Default" : "")}\n";
        }
    }
}
