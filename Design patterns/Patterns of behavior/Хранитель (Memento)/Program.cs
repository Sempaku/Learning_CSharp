using System;
using System.Collections.Generic;

// Паттерн Хранитель (Memento) позволяет выносить внутреннее состояние объекта
// за его пределы для последующего возможного восстановления объекта без нарушения
// принципа инкапсуляции.

// Когда использовать Memento?
// 1 Когда нужно сохранить состояние объекта для возможного последующего
// восстановления
// 2 Когда сохранение состояния должно проходить без нарушения принципа инкапсуляции


// _________________________________________________________________________________

// Теперь рассмотрим реальный пример: нам надо сохранять состояние игрового
// персонажа в игре:
namespace Хранитель__Memento_
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.Shoot();
            hero.Shoot();

            GameHistory history = new GameHistory();
            history.History.Push(hero.SaveState());

            hero.Shoot();

            

            hero.RestoreState(history.History.Pop());
            hero.Shoot();
            
        }
    }

    //Originator
    class Hero
    {
        private int patron = 10;
        private int lives =  5;

        public void Shoot()
        {
            if(patron > 0)
            {
                patron--;
                Console.WriteLine("Shoot! Patrons:{0}",patron);
            }
            else
                Console.WriteLine("No patron");
        }

        public HeroMemento SaveState()
        {
            Console.WriteLine("Save...");
            return new HeroMemento(patron, lives);
        }

        public void RestoreState(HeroMemento memento)
        {
            this.patron = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Restore game...");
        }

    }

    class HeroMemento
    {
        public int Patrons { get; set; }
        public int Lives { get; set; }
        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    // caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
