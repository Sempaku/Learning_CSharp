using System;

// на каждом компьютере можно одномоментно запустить только одну операционную систему.
// В этом плане операционная система будет реализоваться через паттерн синглтон.

namespace Одиночка_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer compik = new Computer();
            compik.Launch("MacOS");
            Console.WriteLine(compik.OS.Name);

            compik.OS = OS.getInstance("Windows 11");
            Console.WriteLine(compik.OS.Name);

            Console.Read();

        }
    }

    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }
    class OS
    {
        private static OS instance;
        public string Name { get; set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance is null)
                instance = new OS(name);
            return instance;
        }

    }
}
