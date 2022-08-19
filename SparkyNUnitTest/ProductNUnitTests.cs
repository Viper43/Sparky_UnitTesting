using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class ProductNUnitTests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
           // _product = new Product();
        }
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            _product = new Product() { Price = 50 };
            var result = _product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            _product = new Product() { Price = 50 };
            var result = _product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));
        }
    }
}
