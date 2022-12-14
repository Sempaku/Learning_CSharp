using System;
using System.Collections.Generic;

//__________________________________________________________________________________

// Рассмотрим пример.
// Допустим, мы проектируем программу для моделирования города.
// Город состоит из отдельных домов, поэтому нам надо создать объекты этих домов.
// Однако домов в городе может быть множество: сотни, тысячи.
// Они могут иметь разный вид, отличаться по различным признакам.
// Однако, как правило, многие дома делаются по стандартным проектам.
// И фактически мы можем выделить несколько типов домов, например, пятиэтажные
// кирпичные хрущевки, многоэтажные панельные высотки и так далее.

// Используя некоторый анализ, мы можем выделить внутренне состояния домов и внешнее.
// К внутреннему состоянию, например, может относиться количество этажей,
// материал (кирпичи, панели и т.д.), или те показатели, которые определены его
// шаблоном, планом проектирования. К внешнему состоянию может относиться положение
// дома на географической карте, то есть его координаты, цвет дома, и так далее,
// то есть такие показатели, которые для каждого отдельного дома могут быть
// относительно индивидуальны.

namespace Приспособленец__Flyweight_
{
    class Program
    {
        static void Main(string[] args)
        {
            double longitude = 22.22;
            double latitude = 90.31;

            HouseFactory hf = new HouseFactory();

            for(int i = 0; i < 5; i++)
            {
                House panelHouse = hf.GetHouse("Panel");
                if (panelHouse != null)
                    panelHouse.Build(longitude, latitude);
                longitude += 5;
                latitude += 3;
            }

            for(int i = 0; i < 5; i++)
            {
                House brickHouse = hf.GetHouse("Brick");
                if (brickHouse != null)
                    brickHouse.Build(longitude, latitude);
                latitude += 5;
                longitude += 3;
            }
        }
    }

    abstract class House
    {
        protected int stages;
        public abstract void Build(double longitude, double latitude);
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine($"Построен панельный дом из {stages} этажей;" +
                $"координаты {latitude} широты и {longitude} долготы ");
        }
    }

    class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine($"Построен кирпичный дом из {stages} этажей;" +
                            $"координаты {latitude} широты и {longitude} долготы ");
        }
    }

    class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();
        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
                return houses[key];
            else
                return null;
        }
    }

}
