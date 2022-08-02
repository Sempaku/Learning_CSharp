using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Command
{
    // Command: интерфейс, представляющий команду.
    // Обычно определяет метод Execute() для выполнения действия,
    // а также нередко включает метод Undo(),
    // реализация которого должна заключаться в отмене действия команды
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }

    // ConcreteCommand: конкретная реализация команды, реализует метод Execute(),
    // в котором вызывается определенный метод, определенный в классе Receiver


    class ConcreteCommand : Command
    {
        Receiver receiver;
        public ConcreteCommand(Receiver r)
        {
            receiver = r;
        }
        public override void Execute()
        {
            receiver.Operation();
        }
        public override void Undo()
        {
            //
        }
    }

    // Receiver получатель команды. Определяет действия, которые должны выполняться
    // в результате запроса.
    class Receiver
    {
        public void Operation() { }
    }

    // Invoker: инициатор команды - вызывает команду для выполнения
    // определенного запроса
    class Invoker
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            command.Execute();
        }
        public void Undo()
        {
            command.Undo();
        }
    }

    // Client: клиент - создает команду и устанавливает ее
    // получателя с помощью метода SetCommand()
    class Client
    {
        void Main()
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand command = new ConcreteCommand(receiver);
            invoker.SetCommand(command);
            invoker.Run();

        }
    }
}
