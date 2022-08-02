using System;
using System.Collections.Generic;
using System.Text;

namespace _L_Liskov_Substitution_Principle
{
    class ProblemPostconditionsExample
    {
        public static void Run()
        {
            AccountPost acc = new MicroAccountPost();
            CalculateInterest(acc); // получаем 1100 без бонуса
        }

        public static void CalculateInterest(AccountPost acc)
        {
            decimal sum = acc.GetInterest(1000, 1, 10); // 1000 + 1000 * 10/100 + 100(bonus)

            if (sum != 1200)
                throw new Exception("Неожиданная сумма при вычислениях");

        }
    }

    class AccountPost
    {
        public virtual decimal GetInterest(int sum, int month, int rate)
        {
            //Preconditions
            if (sum < 0 || month > 12 || month < 1 || rate < 0)
                throw new Exception("Incorrect data");

            decimal result = sum;
            for (int i = 0; i < month; i++)
                result += result * rate / 100;

            //Postconditions
            if (sum >= 1000)
                result += 100;

            return result;
        }


    }

    class MicroAccountPost : AccountPost
    {
        public override decimal GetInterest(int sum, int month, int rate)
        {
            if (sum < 0 || month > 12 || month < 1 || rate < 0)
                throw new Exception("Incorrect data");

            decimal result = sum;

            for(int i = 0; i < month; i++)
            {
                result += result * rate / 100;
            }

            return result;
        }
    }
}
