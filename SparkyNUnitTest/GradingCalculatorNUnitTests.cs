using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCal;

        [SetUp]
        public void Setup()
        {
            _gradingCal = new GradingCalculator();
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_InputScoreAndAttendance_GetProperGrade(int score, int attendance)
        {
            _gradingCal.AttendancePercentage = attendance;
            _gradingCal.Score = score;

            return _gradingCal.GetGrade();
        }
    }
}
