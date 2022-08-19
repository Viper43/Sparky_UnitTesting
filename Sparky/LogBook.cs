using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        public int Severity { get; set; }
        public string LogType { get; set; }
        void Message(string message);
        bool LogToDB(string message);
        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
        string MessageWithReturnStr(string message);
        bool LogWithOutputResult(string message, out string outputStr);
        bool LogWithRefObj(ref Customer customer);
    }
    public class LogBook : ILogBook
    {
        public int Severity { get; set; }
        public string LogType { get; set; }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogToDB(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if( balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message;
        }

        public bool LogWithOutputResult(string message, out string outputStr)
        {
            outputStr = "Hello" + message;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }
    }

    //public class LogBookFaker : ILogBook
    //{
    //    public void Message(string message)
    //    {
    //    }
    //}
}
