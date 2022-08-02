using System;
using System.Threading.Tasks;

// Паттерн "Команда" (Command) позволяет инкапсулировать запрос на выполнение
// определенного действия в виде отдельного объекта.
// Этот объект запроса на действие и называется командой.
// При этом объекты, инициирующие запросы на выполнение действия,
// отделяются от объектов, которые выполняют это действие.

// Команды могут использовать параметры, которые передают ассоциированную с
// командой информацию. Кроме того, команды могут ставиться в очередь и также
// могут быть отменены.

// Когда использовать команды?
//     1 Когда надо передавать в качестве параметров определенные действия,
// вызываемые в ответ на другие действия.
// То есть когда необходимы функции обратного действия
// в ответ на определенные действия.
//     2 Когда необходимо обеспечить выполнение очереди запросов,
// а также их возможную отмену.
//     3 Когда надо поддерживать логгирование изменений в результате запросов.
// Использование логов может помочь восстановить состояние системы - для этого
// необходимо будет использовать последовательность запротоколированных команд.

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
