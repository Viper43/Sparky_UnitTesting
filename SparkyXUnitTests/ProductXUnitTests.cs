using Moq;
using Xunit;

namespace Sparky
{
    public class ProductXUnitTests
    {
        private Product _product;

        
        public ProductXUnitTests()
        {
            //_product = new Product();
        }
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            _product = new Product() { Price = 50 };
            var result = _product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            _product = new Product() { Price = 50 };
            var result = _product.GetPrice(customer.Object);

            Assert.Equal(40, result);
        }
    }
}
