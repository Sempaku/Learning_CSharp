using System;
using System.Collections.Generic;
using System.Text;

namespace Normal_I_Interface_Segregation_Principle
{
    class NormalEmptyMethodsExample
    {
        public static void Run()
        {
            Photograph photograph = new Photograph();
            Camera camera = new Camera();
            photograph.MakePhoto(camera);
        }
    }

    class Photograph
    {
        public void MakePhoto(Camera camera)
        {
            camera.MakePhoto();
        }
    }

    interface ICall
    {
        void Call();
    }
    interface IPhoto
    {
        void MakePhoto();
    }
    interface IVideo
    {
        void MakeVideo();
    }
    interface IWeb
    {
        void BrowseInternet();
    }

    class Camera : IPhoto
    {
        public void MakePhoto()
        {
            Console.WriteLine("Фото на камеру");
        }
    }

    class Phone : ICall, IPhoto, IVideo, IWeb
    {
        public void Call()
        {
            Console.WriteLine("Звоним");
        }
        public void MakePhoto()
        {
            Console.WriteLine("Фотографируем с помощью смартфона");
        }
        public void MakeVideo()
        {
            Console.WriteLine("Снимаем видео");
        }
        public void BrowseInternet()
        {
            Console.WriteLine("Серфим в интернете");
        }
    }
}
