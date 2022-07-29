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
    public class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;

        [SetUp]
        public void Setup()
        {
            //_bankAccount = new BankAccount(new LogBookFaker());
        }

        //[Test]
        //public void DepositLogFaker_Add100_ReturnTrue()
        //{
        //    _bankAccount = new BankAccount(new LogBookFaker());
        //    bool result = _bankAccount.Deposit(100);

        //    Assert.IsTrue(result);
        //    Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        //}

        [Test]
        public void Deposit_Add100_ReturnTrue()
        {
            var logBook = new Mock<ILogBook>();
            logBook.Setup(x => x.Message("Deposited"));

            _bankAccount = new BankAccount(logBook.Object);
            bool result = _bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDB(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdrawal(withdraw);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        [TestCase(200, 400)]
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

            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            
            Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotused = new();


            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);
            
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            
        }

        [Test]
        public void BankLogDummy_SetAndCheckSeverityAndLogTypeMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            
            logMock.Setup(u => u.Severity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");

            Assert.That(logMock.Object.Severity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

        }
    }
}
