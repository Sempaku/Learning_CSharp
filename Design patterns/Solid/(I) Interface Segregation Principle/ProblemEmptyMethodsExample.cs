using System;
using System.Collections.Generic;
using System.Text;

namespace _I_Interface_Segregation_Principle
{
    class ProblemEmptyMethodsExample
    {
        public static void Run()
        {
            Photograph photograph = new Photograph();
            Phone phone = new Phone();
            photograph.TakePhoto(phone);
            Camera camera = new Camera();
            photograph.TakePhoto(camera);
        }
    }

    interface IPhone
    {
        void Call();
        void TakePhoto();
        void MakeVideo();
        void BrowseInternet();
    }

    class Phone : IPhone
    {
        public void Call() => Console.WriteLine("Звоним");
        public void TakePhoto() => Console.WriteLine("Фотографируем на телефон");
        public void MakeVideo() => Console.WriteLine("Снимаем видео");
        public void BrowseInternet() => Console.WriteLine("Серфим в инете");
    }

    class Photograph
    {
        public void TakePhoto(IPhone phone)
        {
            phone.TakePhoto();
        }
    }

    class Camera : IPhone
    {
        public void Call() { }
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем на камеру");
        }
        public void MakeVideo() { }
        public void BrowseInternet() { }
    }
}
