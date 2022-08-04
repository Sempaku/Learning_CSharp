using System;
using System.Threading.Tasks;
//___________________________________________________________________________

// Самая простая ситуация - надо программно организовать включение и выключение
// прибора, например, телевизора

namespace Команда__Command_
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Console.Read();

            // При этом пульт ничего не знает об объекте TV.
            // Он только знает, как отправить команду.
            // В итоге мы получаем гибкую систему, в которой мы легко можем
            // заменять одни команды на другие, создавать последовательности
            // команд. Например, в нашей программе кроме телевизора появилась
            // микроволновка, которой тоже неплохо было бы управлять с
            // помощью одного интерфейса. Для этого достаточно добавить
            // соответствующие классы и установить команду:

            Microwave microwave = new Microwave();
            pult.SetCommand(new MicrowaveCommand(microwave, 5000));
            pult.PressButton();

            Console.Read();

            // Правда, в вышеописанной системе есть один изъян: если мы попытаемся
            // выполнить команду до ее назначения, то программа выдаст исключение,
            // так как команда будет не установлена. Эту проблему мы могли бы
            // решить, проверяя команду на значение null в классе инициатора

            Macro.Macrocommands.Run();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class TV // Receiver
    {
        public void On()
        {
            Console.WriteLine("TV On!");
        }

        public void Off()
        {
            Console.WriteLine("TV Off!");
        }
    }

    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }

        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }

    class Pult // Invoker
    {
        ICommand command;
        public Pult() { }
        
        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            if (command != null)
                command.Execute();
        }
        public void PressUndo()
        {
            if(command != null)
                command.Undo();
        }
    }

    //________________________________________________________________

    class Microwave
    {
        public void StartCooking(int time)
        {
            Console.WriteLine("Подогреваем еду");
            Task.Delay(time).GetAwaiter().GetResult();
        }
        public void StopCooking()
        {
            Console.WriteLine("Еда приготовлена");
        }
    }

    class MicrowaveCommand : ICommand
    {
        Microwave microwave;
        int time;
        public MicrowaveCommand(Microwave m, int t)
        {
            microwave = m;
            time = t;
        }

        public void Execute()
        {
            microwave.StartCooking(time);
            microwave.StopCooking();
        }

        public void Undo()
        {
            microwave.StopCooking();
        }
    }
}
