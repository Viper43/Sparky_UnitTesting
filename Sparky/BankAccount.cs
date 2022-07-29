﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogBook _logbook;
        public BankAccount(ILogBook logbook)
        {
            Balance = 0;
            _logbook = logbook;
        }

        public bool Deposit(int amt)
        {
            _logbook.Message("Deposited");
            Balance += amt;
            return true;
        }

        public bool Withdrawal(int amt)
        {
            if( amt < 0 && amt <= Balance)
            {
                _logbook.LogToDB("Withdrawan amount:-" + amt.ToString());
                Balance -= amt;
                return _logbook.LogBalanceAfterWithdrawal(Balance);
            }
            return _logbook.LogBalanceAfterWithdrawal(Balance - amt);
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
