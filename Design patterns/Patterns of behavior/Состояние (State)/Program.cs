using System;

namespace Состояние__State_
{
    class Program
    {
        static void Main(string[] args)
        {
            Water water1 = new Water(WaterState.SOLID);
            water1.Heat();
            //_________________________________________
            WaterWithStatePattern w = new WaterWithStatePattern(new LiquidWaterState());
            w.Frost();
            w.Frost();
            w.Heat();
            w.Frost();
            w.Heat();
            w.Heat();
            w.Heat();
            w.Frost();
        }
    }

    // Например, вода может находиться в ряде состояний:
    // твердое, жидкое, парообразное.
    // Допустим, нам надо определить класс Вода, у которого бы имелись методы для
    // нагревания и заморозки воды.
    // Без использования паттерна Состояние мы могли бы написать следующую программу

    enum WaterState
    {
        SOLID,
        LIQUID,
        GAS
    }

    class Water
    {
        WaterState State { get; set; }
        public Water(WaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            if (State == WaterState.SOLID)
            {
                Console.WriteLine("Превращаем лед в жидкость");
                State = WaterState.LIQUID;
            }
            else if (State == WaterState.LIQUID)
            {
                Console.WriteLine("Превращаем жидкость в пар");
                State = WaterState.GAS;
            }
            else if (State == WaterState.GAS)
            {
                Console.WriteLine("Повышаем температуру водяного пара");
            }
        }
        public void Frost()
        {
            if (State == WaterState.LIQUID)
            {
                Console.WriteLine("Превращаем жидкость в лед");
                State = WaterState.SOLID;
            }
            else if (State == WaterState.GAS)
            {
                Console.WriteLine("Превращаем водяной пар в жидкость");
                State = WaterState.LIQUID;
            }
        }
    }

    // Вода имеет три состояния, и в каждом методе нам надо смотреть на текущее
    // состояние, чтобы произвести действия. В итоге с трех состояний уже
    // получается нагромождение условных конструкций. Да и самим методов в
    // классе Вода может также быть множество, где также надо будет действовать в
    // зависимости от состояния. Поэтому, чтобы сделать программу более гибкой,
    // в данном случае мы можем применить паттерн Состояние

    class WaterWithStatePattern
    {
        public IWaterState State { get; set; }
        public WaterWithStatePattern(IWaterState iws)
        {
            State = iws;
        }
        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }
    interface IWaterState
    {
        void Heat(WaterWithStatePattern water);
        void Frost(WaterWithStatePattern water);

    }

    class SolidWaterState : IWaterState
    {
        public void Heat(WaterWithStatePattern water)
        {
            Console.WriteLine("ICE --> LIQUID");
            water.State = new LiquidWaterState();
        }
        public void Frost(WaterWithStatePattern water)
        {
            Console.WriteLine("ICE --> ICE");
        }
    }

    class LiquidWaterState : IWaterState
    {
        public void Heat(WaterWithStatePattern water)
        {
            Console.WriteLine("LIQUID --> GAS");
            water.State = new GasWaterState();
        }
        public void Frost(WaterWithStatePattern water)
        {
            Console.WriteLine("LIQUID --> ICE");
            water.State = new SolidWaterState();
        }
    }

    class GasWaterState : IWaterState
    {
        public void Heat(WaterWithStatePattern water)
        {
            Console.WriteLine("GAS --> GAS");            
        }
        public void Frost(WaterWithStatePattern water)
        {
            Console.WriteLine("GAS --> LIQUID");
            water.State = new LiquidWaterState();
        }
    }

}
