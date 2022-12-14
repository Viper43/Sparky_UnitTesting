using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        
        int Discount { get; set; }
        string GreetingMsg { get; set; }

        int OrderTotal { get; set; }

        bool IsPlatinum { get; set; }

        string GreetAndCombineNames(string firstName, string lastName);

        CustomerType GetCustomerType();
    }
    public class Customer : ICustomer
    {
        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

        public int Discount { get; set; }
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
