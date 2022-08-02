using System;
using System.Reflection;


namespace Исследование_методов_и_конструкторов_с_помощью_рефлексии
{
    class Program
    {
        static void Main(string[] args)
        {
            //Получение информации о методах
            //Для получения получении информации отдельно о методах применяется метод GetMethods().
            //Этот метод возвращает все методы типа в виде массива объектов MethodInfo

            Type myType = typeof(Printer);

            Console.WriteLine("Methods: ");
            foreach(MethodInfo method in myType.GetMethods())
            {
                string modificator = "";

                //if static method
                if (method.IsStatic) modificator += "static ";

                //if virtual method
                if (method.IsVirtual) modificator += "virtual ";

                Console.WriteLine($"{modificator} {method.ReturnType.Name} {method.Name}()");
            }

            Console.WriteLine("__________________________");
            //_______________________________________________________________________________
            // BindingFlags

            //В примере выше использовалась простая форма метода GetMethods(),
            //которая извлекает все общедоступные публичные методы.
            //Но мы можем использовать и другую форму метода: MethodInfo[] GetMethods(BindingFlags).
            //Объединяя значения BindingFlags можно комбинировать вывод

            Console.WriteLine("Methods: ");
            foreach(MethodInfo method in myType.GetMethods(BindingFlags.DeclaredOnly
                                | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"{method.ReturnType.Name} - {method.Name}()");


            Console.WriteLine("_________________________");
            //______________________________________________________________________________
            //Исследование параметров

            //С помощью метода GetParameters() можно получить все параметры метода
            //в виде массива объектов ParameterInfo

            foreach(MethodInfo metod in typeof(Printer).GetMethods())
            {
                Console.Write($"{metod.ReturnType.Name} - {metod.Name} ( ");
                ParameterInfo[] parameters = metod.GetParameters();
                for(int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    string modif = "";

                    if (param.IsIn) modif += "in ";
                    else if (param.IsOut) modif += "out ";

                    Console.Write($"{param.ParameterType.Name} {modif} {param.Name}");

                    if (param.HasDefaultValue) Console.Write($"={param.DefaultValue}");

                    if (i < parameters.Length - 1) Console.Write(", ");
                    
                }
                Console.WriteLine(')');
            }


            Console.WriteLine("________________________________");
            //______________________________________________________________________
            //Вызов методов

            //С помощью метода Invoke() можно вызвать метод:
            //public object? Invoke (object? obj, object?[]? parameters);

            var myPrinter = new Printer2("Hello");
            var print = typeof(Printer2).GetMethod("Print");

            print?.Invoke(myPrinter, parameters: null);


            Console.WriteLine("____________________________________");
            //_________________________________________________________
            //Получение конструкторов

            //Для получения конструкторов применяется метод GetConstructors(),
            //который возвращает массив объектов класса ConstructorInfo.
            //Этот класс во многом похож на MethodInfo и имеет ряд общей функциональности

            Type typePerson = typeof(Person);

            Console.WriteLine("Constructors: ");
            foreach(ConstructorInfo ctor in typePerson.GetConstructors(BindingFlags.Instance |
                                            BindingFlags.NonPublic | BindingFlags.Public))
            {
                string mod = "";

                if (ctor.IsPublic)
                    mod += "public ";
                else if (ctor.IsPrivate)
                    mod += "private ";
                else if (ctor.IsAssembly)
                    mod += "internal ";
                else if (ctor.IsFamily)
                    mod += "protected ";
                else if (ctor.IsFamilyAndAssembly)
                    mod += "private protected ";
                else if (ctor.IsFamilyOrAssembly)
                    mod += "protected internal ";

                Console.Write($"{mod} {typePerson.Name} (");
                ParameterInfo[] parameters = ctor.GetParameters();
                for(int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

        }
    }
        
    class Printer
    {
        public string DefaultMessage { get; set; } = "Hello";
        public void PrintMessage(string message, int times = 1)
        {
            while (times-- > 0) Console.WriteLine(message) ;
        }
        public string CreateMessage() => DefaultMessage;
    }
    class Printer2
    {
        public string Text { get; }
        public Printer2(string text) => Text = text;
        public void Print() => Console.WriteLine(Text);

    }
    class Person
    {
        public string Name { get;  }
        public int Age { get; }
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        public Person(string name) : this(name, 1) { }
        private Person() : this("Tom") { }
    }
}
