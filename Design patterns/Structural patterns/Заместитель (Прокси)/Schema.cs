using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Прокси_
{
    // Client: использует объект Proxy для доступа к объекту RealSubject
    class Client
    {
        public static void Run()
        {
            Subject subject = new Proxy();
            subject.Request();
        }
    }

    // Subject: определяет общий интерфейс для Proxy и RealSubject.
    // Поэтому Proxy может использоваться вместо RealSubject
    abstract class Subject
    {
        public abstract void Request();
    }

    // RealSubject: представляет реальный объект, для которого создается прокси
    class RealSubject : Subject
    {
        public override void Request()
        {
            //
        }
    }

    // Proxy: заместитель реального объекта. Хранит ссылку на реальный объект,
    // контролирует к нему доступ, может управлять его созданием и удалением.
    // При необходимости Proxy переадресует запросы объекту RealSubject
    class Proxy : Subject
    {
        RealSubject realSubject;
        public override void Request()
        {
            if (realSubject == null)
                realSubject = new RealSubject();
            realSubject.Request();
        }
    }
}
