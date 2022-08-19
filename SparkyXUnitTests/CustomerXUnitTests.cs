using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer _customer;

        public CustomerXUnitTests()
        {
            _customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange

            // Act
            _customer.GreetAndCombineNames("Eleven", "El");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal("Hello, Eleven El", _customer.GreetingMsg);
                Assert.Contains(("eleven el").ToLower(), _customer.GreetingMsg.ToLower());
                Assert.StartsWith("Hello", _customer.GreetingMsg);
                Assert.EndsWith("El", _customer.GreetingMsg);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _customer.GreetingMsg);
            });
        }

        [Fact]
        public void GreetingMsg_NotGreeted_ReturnsNull()
        {
            // Arrange


            // Act
            //string fullName = customer.GreetAndCombineNames("Eleven", "El");

            // Assert
            Assert.Null(_customer.GreetingMsg);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            // Arrange
            // Act
            int result = _customer.Discount;
            // Assert
            Assert.InRange(result, 10, 20);
        }

        [Fact]
        public void GreetMessage_GreetWithoutLastName_ReturnsNotNull()
        {
            // Arrange
            // Act
            _customer.GreetAndCombineNames("Eleven", "");
            // Assert
            Assert.NotNull(_customer.GreetingMsg);
            Assert.False(string.IsNullOrEmpty(_customer.GreetingMsg));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "El"));

            Assert.Equal("First Name is Empty", exceptionDetails.Message);
            
            Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "El"));
        }

        [Fact]
        public void CustomerType_InputOrderTotal_ReturnCustomerTypeAsBasicIfOrderTotalLessThan100()
        {
            _customer.OrderTotal = 50;
            var result = _customer.GetCustomerType();

            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_InputOrderTotal_ReturnCustomerTypeAsPlatinumIfOrderTotalMoreThan100()
        {
            _customer.OrderTotal = 150;
            var result = _customer.GetCustomerType();

            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
