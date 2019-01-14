using System;
using System.Collections.Generic;
using System.Text;

namespace DomainWithEF.Domain.Customers
{
    public class Customer : BaseModel
    {
        public string CustomerName { get; private set; }
        public decimal Balance { get; private set; }
        public List<Address> Addresses { get; private set; }
        public decimal LastPayment { get; private set; }
        public bool IsDeleted { get; private set; }
        private Customer(Guid id, string customerName, decimal openingBalance, string houseNumber, string street, string block, string city, string country)
        {
            if (String.IsNullOrEmpty(customerName))
                throw new ArgumentNullException("invalid argument!");

            base.Id = Guid.NewGuid();
            this.CustomerName = customerName;
            this.Balance = openingBalance;
            this.Addresses = new List<Address>();

            var address = new Address(this, houseNumber, street, block, city, country);
            address.MakeAsDefault();

            this.Addresses.Add(address);
        }

        public static Customer CreateNewCustomer(string customerName, decimal openingBalance, string houseNumber, string street, string block, string city, string country)
        {
            return new Customer(Guid.NewGuid(), customerName,  openingBalance,  houseNumber,  street, block, city, country);
        }

        public void ChangeName(string newCustomerName)
        {
            this.CustomerName = newCustomerName;
        }
        public void Pay(decimal amount)
        {
            if (this.IsDeleted)
                throw new Exception("Deleted customer cannot pay any amount!");

            this.LastPayment = amount;
            this.Balance -= amount;
        }

        public void Charge(decimal amount)
        {
            if (this.IsDeleted)
                throw new Exception("Deleted customer cannot be charged any amount!");

            this.Balance += amount;
        }

        public void AddAddress(string houseNumber, string street, string block, string city, string country,bool makeAsDefault)
        {
            var newAddress = new Address(this, houseNumber, street, block, city, country);

            if (makeAsDefault)
                newAddress.MakeAsDefault();
            
            this.Addresses.Add(newAddress);
        }
        public void Delete()
        {
            if (!this.IsDeleted)
                this.IsDeleted = true;
        }

        public override string ToString()
        {
            if (this.IsDeleted)
                return "The customer has been deleted!";

            string msg = $"Customer: { this.CustomerName}, Balance: {this.Balance}, Last payment: BD {this.LastPayment}\n";
            foreach (var address in this.Addresses)
                msg += address.ToString();
            return msg;
        }
    }
}
