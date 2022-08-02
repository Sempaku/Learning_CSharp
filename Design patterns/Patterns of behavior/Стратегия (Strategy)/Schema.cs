using System;
using System.Collections.Generic;
using System.Text;

namespace Стратегия_Strategy
{
    // Это общий интерфейс для всех реализующих его алгоритмов.
    // Вместо интерфейса здесь также можно было бы использовать абстрактный класс.
    public interface IStrategy
    {
        void Algorithm();
    }

    // Классы ConcreteStrategy1 и ConcreteStrategy2, которые реализуют
    // интерфейс IStrategy, предоставляя свою версию метода Algorithm().
    // Подобных классов-реализаций может быть множество.
    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm() { }
    }
    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm() { }
    }

    // Класс Context хранит ссылку на объект IStrategy и
    // связан с интерфейсом IStrategy отношением агрегации.
    public class Context
    {
        public IStrategy ContextStrategy { get; set; }
        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }


}
