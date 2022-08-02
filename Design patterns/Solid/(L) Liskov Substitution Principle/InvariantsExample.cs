using System;
using System.Collections.Generic;
using System.Text;

namespace _L_Liskov_Substitution_Principle
{
    class InvariantsExample
    {
    }

    class User
    {
        protected int age;
        public User(int age)
        {
            if (age < 0)
                throw new Exception("Возраст не может быть меньше 0");

            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new Exception("Возраст не может быть меньше 0");

                this.age = age;
            }
        }
    }
}
