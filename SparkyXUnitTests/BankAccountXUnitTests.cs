using Moq;
using Xunit;

namespace Sparky
{
    public class BankAccountXUnitTests
    {
        private BankAccount _bankAccount;

        //public BankAccountXUnitTests()
        //{
        //    //_bankAccount = new BankAccount(new LogBookFaker());
        //}

        //[Test]
        //public void DepositLogFaker_Add100_ReturnTrue()
        //{
        //    _bankAccount = new BankAccount(new LogBookFaker());
        //    bool result = _bankAccount.Deposit(100);

        //    Assert.IsTrue(result);
        //    Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        //}

        [Fact]
        public void Deposit_Add100_ReturnTrue()
        {
            var logBook = new Mock<ILogBook>();
            logBook.Setup(x => x.Message("Deposited"));

            _bankAccount = new BankAccount(logBook.Object);
            bool result = _bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, _bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdrawal(withdraw);

            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        [InlineData(200, 400)]
        public void BankWithdraw_WithdrawMoreThanBalanceWith200Balance_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdrawal(withdraw);

            Assert.False(result);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.Equal(desiredOutput, logMock.Object.MessageWithReturnStr("Hello"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.True(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.Equal(desiredOutput, result);
        }

        [Fact]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotused = new();


            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

            Assert.True(logMock.Object.LogWithRefObj(ref customer));

        }

        [Fact]
        public void BankLogDummy_SetAndCheckSeverityAndLogTypeMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.Severity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");

            Assert.Equal(10, logMock.Object.Severity);
            Assert.Equal("warning", logMock.Object.LogType);

            // callback
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDB("Eleven");
            Assert.Equal("Hello, Eleven", logTemp);

            // callback
            int count = 5;
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true).Callback(() => count++);
            logMock.Object.LogToDB("Eleven");
            Assert.Equal(6, count);

        }

        [Fact]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);

            Assert.Equal(100, bankAccount.GetBalance());

            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.Severity = 101, Times.Once);
        }
    }
}
