using System;
// Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс для
// создания семейств взаимосвязанных объектов с определенными интерфейсами без указания
// конкретных типов данных объектов.

// Когда использовать абстрактную фабрику
//     1 Когда система не должна зависеть от способа создания и компоновки новых объектов
//     2 Когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными

//_________________________________________________________________________________________

// Mы делаем игру, где пользователь должен управлять некими супергероями, при этом
// каждый супергерой имеет определенное оружие и определенную модель передвижения.
// Различные супергерои могут определяться комплексом признаков.
// Например, эльф может летать и должен стрелять из арбалета, другой супергерой
// должен бегать и управлять мечом. Таким образом, получается, что сущность оружия
// и модель передвижения являются взаимосвязанными и используются в комплексе.
// То есть имеется один из доводов в пользу использования абстрактной фабрики.

// И кроме того, наша задача при проектировании игры абстрагировать создание супергероев
// от самого класса супергероя, чтобы создать более гибкую архитектуру.

namespace АбстрактнаяфабрикаAbstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elfBlackBook = new Hero(new ElfFactory());
            elfBlackBook.Run();
            elfBlackBook.Hit();

            Hero Gatsu = new Hero(new BerserkFactory());
            Gatsu.Hit();
            Gatsu.Run();


        }
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }

    abstract class Movement
    {
        public abstract void Move();
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }

    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечем!");
        }
    }

    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим...");
        }
    }
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим...");
        }
    }

    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }
        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    class BerserkFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }
        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    //client

    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            movement = factory.CreateMovement();
            weapon = factory.CreateWeapon();
        }

        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
