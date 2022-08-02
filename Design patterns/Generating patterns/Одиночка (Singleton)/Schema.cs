using System;
using System.Collections.Generic;
using System.Text;

namespace Одиночка_Singleton
{
    class Singleton
    {
        // ссылка на конкретный экземпляр данного объекта
        private static Singleton instance;
        
        // пустой конструктор
        public Singleton() { }

        // метод для создания объекта (если объекта нет or null)
        public static Singleton getInstance()
        {
            if (instance is null)
                instance = new Singleton();
            return instance;
        }
        

    }
}
