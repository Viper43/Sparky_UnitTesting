using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator _gradingCal;

        
        public GradingCalculatorXUnitTests()
        {
            _gradingCal = new GradingCalculator();
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_InputScoreAndAttendance_GetProperGrade(int score, int attendance, string expectedResult)
        {
            _gradingCal.AttendancePercentage = attendance;
            _gradingCal.Score = score;

            Assert.Equal(expectedResult, _gradingCal.GetGrade());
        }
    }
}
