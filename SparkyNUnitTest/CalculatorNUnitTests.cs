using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange
            

            // Act
            int result = _calc.AddNumbers(10, 20);

            // Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenInt_ReturnFalse()
        {
            // Assign
            

            // Act
            bool isOdd = _calc.IsOddNumber(10);

            // Assert
            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(17)]
        public void IsOddChecker_InputOddInt_ReturnTrue(int a)
        {
            // Assign
            

            // Act
            bool isOdd = _calc.IsOddNumber(a);

            // Assert
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputInt_ReturnTrueIfOdd(int a)
        {
            // Assign
            

            // Act
            return _calc.IsOddNumber(a);

            // Assert
            //Assert.That(isOdd, Is.EqualTo(true));
            //Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(5.4, 10.5 /*, ExpectedResult = 15.9*/)]
        [TestCase(5.43, 10.53 /*, ExpectedResult = 15.96*/)]
        [TestCase(5.49, 10.59 /*, ExpectedResult = 16.08*/)]
        public void AddNumbers_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // Arrange
            

            // Act
            var result = _calc.AddNumbers(a, b);

            // Assert
            Assert.AreEqual(15.9, result, .2);
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new List<int>() { 5, 7, 9};

            List<int> result = _calc.GetOddRange(5, 10);

            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(expectedOddRange.Count));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
