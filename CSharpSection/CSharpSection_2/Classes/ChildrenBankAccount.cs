using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSection_2.Classes
{
    public class ChildrenBankAccount : BankAccount
    {
        public string Parent { get; set; }

        public ChildrenBankAccount(float balance, string owner, string parent) : base(balance, owner)
        {
            Parent = parent;
        }

        public override float AddBalance(float balanceToBeAdded)
        {
            if(balanceToBeAdded >= -10)
                return base.AddBalance(balanceToBeAdded);
            return Balance;
        }

        public override float AddBalance(float balanceToBeAdded, bool balanceCanBeNegative)
        {
            if(balanceToBeAdded >= -10)
                return base.AddBalance(balanceToBeAdded, balanceCanBeNegative);
            return Balance;
        }
    }
}
