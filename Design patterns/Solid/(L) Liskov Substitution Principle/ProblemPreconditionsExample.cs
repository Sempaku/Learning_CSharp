using System;
using System.Collections.Generic;
using System.Text;

namespace _L_Liskov_Substitution_Principle
{
    class ProblemPreconditionsExample
    {
        public static void Run()
        {
            AccountPre acc = new MicroAccountPre();
            InitAccount(acc);   
        }

        public static void InitAccount(AccountPre account)
        {
            account.SetCapital(200);
            Console.WriteLine(account.Capital);
        }
    }

    class AccountPre
    {
        public int Capital { get; protected set; }
        
        public virtual void SetCapital(int money)
        {
            if (money < 0)
                throw new Exception("Нельзя положить на сет меньше 0!!!");
            this.Capital = money;
        }        
    }

    class MicroAccountPre : AccountPre
    {
        public override void SetCapital(int money)
        {
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0");
            else if (money > 100)
                //throw new Exception("Нельзя положить на счет больше 100");
                Console.WriteLine("Error");
            this.Capital = money;
        }
    }
}
