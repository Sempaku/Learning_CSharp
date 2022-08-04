using System;
using System.Collections.Generic;

// Например, нам надо разработать программ для вычислений простейших операций
// сложения и вычитания с помощью переменных: x + y - z.
// Для этого можно определить следующую грамматику:

// IExpression ::= NumberExpression | Constant | AddExpression | SubtractExpression
// AddExpression::= IExpression + IExpression
// SubtractExpression::= IExpression - IExpression
// NumberExpression::= [A - Z, a - z] +
// Constant::= [1 - 9] +

namespace Интерпретатор__Interpreter_
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            int x = 5;
            int y = 8;
            int z = 2;

            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);

            IExpression expression = new SubstractExpression(
                new AddExpression(
                    new NumberExpression("x"), new NumberExpression("y")
                    ),
                    new NumberExpression("z")
                    );

            int res = expression.Interpret(context);
            Console.WriteLine("Result: {0}",res);
        }
    }

    class Context
    {
        Dictionary<string , int> variables;
        public Context()
        {
            variables = new Dictionary<string, int>();
        }

        // получаем значение переменной по ее имени
        public int GetVariable(string name)
        {
            return variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }

    }
    interface IExpression
    {
        int Interpret(Context context);
    }
    class NumberExpression : IExpression
    {
        string name;
        public NumberExpression(string variableName)
        {
            name = variableName;
        }
        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }

    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    class SubstractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public SubstractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }

}
