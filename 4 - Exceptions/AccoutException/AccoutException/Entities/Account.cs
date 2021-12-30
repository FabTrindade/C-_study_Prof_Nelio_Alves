using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccountException.Entities.Exceptions;

namespace AccountException.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }

        public double Balance { get; set; }

        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {

            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit (double amount)
        {   
            Balance += amount;
        }
        public void Withdraw (double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("Withdraw error: The amount exceeds withdraw limit");
            }
            if ((Balance <= 0) || (amount > Balance))
            {
                throw new DomainException("Withdraw error: Not enough balance!");
            }
            
            Balance -= amount;
        }
    }
}
