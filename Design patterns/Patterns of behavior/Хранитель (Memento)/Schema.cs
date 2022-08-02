using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Memento_
{
    // Memento: хранитель, который сохраняет состояние объекта Originator и
    // предоставляет полный доступ только этому объекту Originator
    class Memento
    {
        public string State { get; set; }
        public Memento(string state)
        {
            this.State = state;
        }
    }

    // Caretaker: выполняет только функцию хранения объекта Memento,
    // в то же время у него нет полного доступа к хранителю и никаких
    // других операций над хранителем, кроме собственно сохранения,
    // он не производит
    class Caretaker
    {
        public Memento Memento { get; set; }
    }

    // Originator: создает объект хранителя для сохранения своего состояния
    class Originator
    {
        public string State { get; set; }
        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }
}
