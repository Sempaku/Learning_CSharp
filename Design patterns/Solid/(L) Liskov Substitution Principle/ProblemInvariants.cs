using System;
using System.Collections.Generic;
using System.Text;

namespace _L_Liskov_Substitution_Principle
{
    class ProblemInvariants
    {
    }

    class AccountInv
    {
        protected int capital;
        public AccountInv(int sum)
        {
            if (sum < 100)
                throw new Exception("Некорректная сумма");

            this.capital = sum;
        }

        public virtual int Capital
        {
            get { return capital; }
            set
            {
                if (value < 100)
                    throw new Exception("Некорректная сумма");

                capital = value;
            }
        }
    }

    class MicroAccount : AccountInv
    {
        public MicroAccount(int sum) : base(sum)
        {

        }

        public override int Capital
        {
            get { return capital; }
            set
            {
                capital = value;
            }
        }
    }
}
