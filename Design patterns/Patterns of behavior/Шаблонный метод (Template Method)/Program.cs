using System;
//_________________________________________________________________________________

// Допустим, в нашей программе используются объекты, представляющие учебу в
// школе и в вузе:
namespace Шаблонный_метод__Template_Method_
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolTemplate school = new SchoolTemplate();
            UniversityTemplate university = new UniversityTemplate();

            school.Learn();
            university.Learn();
        }
    }
    // Обычный метод
    class School
    {
        public void Enter() { } // идем в 1 класс
        public void Study() { } // обучение
        public void PassExam() { } // сдаем выпускные экзамены
        public void GetAttestat() { } // получаем аттестат
    }

    class University
    {
        // поступление в университет
        public void Enter() { }
        // обучение
        public void Study() { }
        // проходим практику
        public void Practice() { }
        // сдаем выпускные экзамены
        public void PassExams() { }
        // получение диплома
        public void GetDiplom() { }
    }

    // ____________________________________________________________________________

    // template

    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExam();
            GetDocum();
        }
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExam()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }
        public abstract void GetDocum();
    }

    class SchoolTemplate : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в 1 класс");
        }
        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, демаем домашку");
        }
        public override void GetDocum()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }

    class UniversityTemplate : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в ВУЗ");
        }
        public override void Study()
        {
            Console.WriteLine("Посещаем пары");
        }

        public override void PassExam()
        {
            Console.WriteLine("Сдаем экзамен по специальности");
        }
        public override void GetDocum()
        {
            Console.WriteLine("Получаем диплом о высшем образовании");
        }
    }
}
