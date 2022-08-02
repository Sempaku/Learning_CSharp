using System;
using System.Collections.Generic;
using System.Text;

namespace Macro
{
    public static class Macrocommands
    {
        public static void Run()
        {
            Programmer programmer = new Programmer();
            Tester tester = new Tester();
            Marketolog marketolog = new Marketolog();

            List<ICommand> commands = new List<ICommand>()
            {
                new CodeCommand(programmer),
                new TestCommand(tester),
                new AdvetrizeCommand(marketolog)
            };

            Manager manager = new Manager();
            manager.SetCommand(new MacroCommand(commands));
            manager.StartProject();
            manager.StopProject();

            Console.Read();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class MacroCommand : ICommand
    {
        List<ICommand> commands;
        public MacroCommand(List<ICommand> coms)
        {
            commands = coms;
        }
        public void Execute()
        {
            foreach (ICommand c in commands)
                c.Execute();
        }

        public void Undo()
        {
            foreach (ICommand c in commands)
                c.Undo();   
        }
    }

    class Programmer
    {
        public void StartCoding()
        {
            Console.WriteLine("The programmer writes code...");
        }

        public void StopCoding()
        {
            Console.WriteLine("The programmer stopped...");
        }
    }

    class Tester
    {
        public void StartTest()
        {
            Console.WriteLine("The tester start testing the product");
        }
        public void StopTest()
        {
            Console.WriteLine("Tester stopped testing");
        }
    }

    class Marketolog
    {
        public void StartAdvertize()
        {
            Console.WriteLine("The marketer begins to advertise the product");
        }
        public void StopAdvertize()
        {
            Console.WriteLine("The marketer stopped advertising the product");
        }
    }

    class CodeCommand : ICommand
    {
        Programmer programmer;
        public CodeCommand(Programmer p)
        {
            programmer = p;
        }
        public void Execute()
        {
            programmer.StartCoding();
        }
        public void Undo()
        {
            programmer.StopCoding();
        }
    }

    class TestCommand : ICommand
    {
        Tester tester;
        public TestCommand(Tester t)
        {
            tester = t;
        }
        public void Execute()
        {
            tester.StartTest();
        }
        public void Undo()
        {
            tester.StopTest();
        }
    }

    class AdvetrizeCommand : ICommand
    {
        Marketolog marketolog;
        public AdvetrizeCommand(Marketolog m)
        {
            marketolog = m;
        }
        public void Execute()
        {
            marketolog.StartAdvertize();
        }
        public void Undo()
        {
            marketolog.StopAdvertize();
        }
    }

    class Manager
    {
        ICommand command;
        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void StartProject()
        {
            if (command != null)
                command.Execute();
        }
        public void StopProject()
        {
            if (command != null)
                command.Undo();
        }
    }
}
