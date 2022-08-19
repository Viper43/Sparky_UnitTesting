using Xunit;

namespace Sparky
{
    
    public class FiboXUnitTests
    {
        private Fibo _fibo;
        
        public FiboXUnitTests()
        {
            _fibo = new Fibo();
        }
        
        [Fact]
        public void FiboChecker_Input1_returnsFiboSeries()
        {
            List<int> expectedRange = new List<int>() { 0 };
            _fibo.Range = 1;

            List<int> result = _fibo.GetFiboSeries();

            Assert.Contains(0, result);
            Assert.Equal(expectedRange.Count, result.Count);
            Assert.Equal(result.OrderBy(r=>r), result);
            Assert.Equal(expectedRange, result);
        }

        [Fact]
        public void FiboChecker_Input6_returnsFiboSeries()
        {
            List<int> expectedRange = new List<int>() { 0, 1 , 1, 2, 3, 5};
            _fibo.Range = 6;

            List<int> result = _fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.Equal(expectedRange.Count, result.Count);
            Assert.Equal(result.OrderBy(r => r), result);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expectedRange, result);
        }
    }
}
