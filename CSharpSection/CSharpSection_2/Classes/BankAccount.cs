using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSection_2.Classes
{
    public class BankAccount
    {
        private float balance;
        public float Balance
        {
            get
            {
                return balance;
            }

            private set
            {
                if (value >= 0)
                    balance = value;
                else
                    balance = 0;
            }
        }

        private string owner;

        public BankAccount(float balance, string owner)
        {
            Balance = balance;
            this.owner = owner;
        }

        public virtual float AddBalance(float blanaceToBeAdded)
        {
            Balance = balance + blanaceToBeAdded;
            return Balance;
        }

        public virtual float AddBalance(float balanceToBeAdded, bool balanceCanBeNegative)
        {
            if (balanceCanBeNegative)
                balance = balance + balanceToBeAdded;
            else
                Balance = balance + balanceToBeAdded;

            return Balance;
        }

        public async Task<string> GetData()
        {
            Thread.Sleep(2000);

            return "Completed";
        }
    }
}
