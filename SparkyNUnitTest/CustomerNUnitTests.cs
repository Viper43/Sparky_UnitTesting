using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            

            // Act
            _customer.GreetAndCombineNames("Debdita", "Kar");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(_customer.GreetingMsg, Is.EqualTo("Hello, Debdita Kar"));
                Assert.AreEqual("Hello, Debdita Kar", _customer.GreetingMsg);
                Assert.That(_customer.GreetingMsg, Does.Contain("debdita kar").IgnoreCase);
                Assert.That(_customer.GreetingMsg, Does.StartWith("Hello"));
                Assert.That(_customer.GreetingMsg, Does.EndWith("Kar"));
                Assert.That(_customer.GreetingMsg, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetingMsg_NotGreeted_ReturnsNull()
        {
            // Arrange
            

            // Act
            //string fullName = customer.GreetAndCombineNames("Debdita", "Kar");

            // Assert
            Assert.IsNull(_customer.GreetingMsg);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            // Arrange


            // Act
            int result = _customer.Discount;

            // Assert
            Assert.That(result, Is.InRange(10, 20));
        }

        [Test]
        public void GreetMessage_GreetWithoutLastName_ReturnsNotNull()
        {
            // Arrange
            // Act
            _customer.GreetAndCombineNames("Debdita", "");

            // Assert
            Assert.IsNotNull(_customer.GreetingMsg);
            Assert.IsFalse(string.IsNullOrEmpty(_customer.GreetingMsg));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Kar"));

            Assert.AreEqual("First Name is Empty", exceptionDetails.Message);
            Assert.That(() => _customer.GreetAndCombineNames("", "Kar"), Throws.ArgumentException.With.Message.EqualTo("First Name is Empty"));

            Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Kar"));

            Assert.That(() => _customer.GreetAndCombineNames("", "Kar"), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_InputOrderTotal_ReturnCustomerTypeAsBasicIfOrderTotalLessThan100()
        {
            _customer.OrderTotal = 50;
            var result = _customer.GetCustomerType();

            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public  void CustomerType_InputOrderTotal_ReturnCustomerTypeAsPlatinumIfOrderTotalMoreThan100()
        {
            _customer.OrderTotal = 150;
            var result = _customer.GetCustomerType();

            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
