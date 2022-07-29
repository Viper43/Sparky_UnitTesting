using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public Customer()
        {
            IsPlatinum = false;
        }

        public int Discount = 15;
        public string GreetingMsg { get; set; }

        public int OrderTotal { get; set; }

        public bool IsPlatinum { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First Name is Empty");
            }
            GreetingMsg = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetingMsg;
        }

        public CustomerType GetCustomerType()
        {
            if (OrderTotal < 100)
                return new BasicCustomer();

            return new PlatinumCustomer();
        }
    }

    
    public class CustomerType { }
    
    public class BasicCustomer : CustomerType { }

    public class PlatinumCustomer : CustomerType { }

}
