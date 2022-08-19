using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class CalculatorXUnitTests
    {
        private Calculator _calc;

        public CalculatorXUnitTests()
        {
            _calc = new Calculator();
        }

        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange
            // Act
            int result = _calc.AddNumbers(10, 20);

            // Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputEvenInt_ReturnFalse()
        {
            // Assign
            

            // Act
            bool isOdd = _calc.IsOddNumber(10);

            // Assert
            //Assert.That(isOdd, Is.EqualTo(false));
            Assert.False(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(17)]
        public void IsOddChecker_InputOddInt_ReturnTrue(int a)
        {
            // Assign
            

            // Act
            bool isOdd = _calc.IsOddNumber(a);

            // Assert
            //Assert.That(isOdd, Is.EqualTo(true));
            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputInt_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            // Assign
            

            // Act
            var result = _calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);

            // Assert
            //Assert.That(isOdd, Is.EqualTo(true));
            //Assert.IsTrue(isOdd);
        }

        [Theory]
        [InlineData(5.4, 10.5, 15.9)]
        [InlineData(5.43, 10.53, 15.96)]
        [InlineData(5.49, 10.59, 16.08)]
        public void AddNumbers_InputTwoDouble_GetCorrectAddition(double a, double b, double expectedresult)
        {
            // Arrange
            

            // Act
            var result = _calc.AddNumbers(a, b);

            // Assert
            Assert.Equal(expectedresult, result, 2);
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new List<int>() { 5, 7, 9};

            List<int> result = _calc.GetOddRange(5, 10);

            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedOddRange.Count, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(x => x), result);
            //Assert.That(result, Is.Unique);
        }
    }
}
