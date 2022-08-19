using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        [Test]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(100, ExpectedResult = true)]
        public bool DateValidator_InputExpectedDateRange_DateValidity(int addTime)
        {
            DateInFutureAttribute dateInFutureAttribute = new(() => DateTime.Now);
            return dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addTime));

            //Assert.AreEqual(true, result);
        }

        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();
            Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
}