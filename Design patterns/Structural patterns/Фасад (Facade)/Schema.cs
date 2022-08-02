using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Facade_
{
    // Client взаимодействует с компонентами подсистемы
    class Client
    {
        public static void Run()
        {
            Facade facade = new Facade(new SubsysA(), new SubsysB(), new SubsysC());
            facade.Operation1();
            facade.Operation2();
        }
    }

    // Классы SubsystemA, SubsystemB, SubsystemC и т.д. являются компонентами
    // сложной подсистемы, с которыми должен взаимодействовать клиент
    class SubsysA
    {
        public void A1() { }
    }

    class SubsysB
    {
        public void B1() { }
    }

    class SubsysC
    {
        public void C1() { }
    }

    // Facade - непосредственно фасад, который предоставляет интерфейс
    // клиенту для работы с компонентами
    class Facade
    {
        SubsysA subsysA;
        SubsysB subsysB;
        SubsysC subsysC;

        public Facade(SubsysA sa, SubsysB sb, SubsysC sc)
        {
            subsysC = sc;
            subsysB = sb;
            subsysA = sa;
        }

        public void Operation1()
        {
            subsysA.A1();
            subsysB.B1();
            subsysC.C1();
        }

        public void Operation2()
        {
            subsysC.C1();
            subsysA.A1();
        }
    }
}
