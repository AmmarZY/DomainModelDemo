using System;
using DomainWithEF.Domain.Customers;

namespace DomainWithEF
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var customer1 = Customer.CreateNewCustomer("Fadel Ali", 0, "592","211","302","Manama","Bahrain");
                
                Console.WriteLine(customer1.ToString());
                customer1.AddAddress("333", "222", "111", "Isa Town", "Bahrain", true);
                Console.WriteLine(customer1.ToString());

                //customer1.Charge(100);
                //Console.WriteLine(customer1.ToString());
                //customer1.Pay(30);
                //Console.WriteLine(customer1.ToString());
                //customer1.Delete();
                //Console.WriteLine(customer1.ToString());
                //customer1.Charge(20);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error:" + exp.Message);
            }
            Console.ReadKey();
        }
    }
}
