using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Xml.Linq;

class Program
{
    abstract class Car<TEngine> where TEngine : Engine
    {
        public TEngine Engine { get; set; }

        public abstract void ChangePart<TCarPart>(TCarPart newPart) where TCarPart : CarParts;

    }

    class ElectricCar : Car<ElectricEngine>
    {
        public override void ChangePart<TCarPart>(TCarPart newPart)
        {
            throw new NotImplementedException();
        }
    }
    class GasCar : Car<GasEngine>
    {
        public override void ChangePart<TCarPart>(TCarPart newPart)
        {
            throw new NotImplementedException();
        }
    }
    abstract class Engine { }
    class ElectricEngine : Engine { }
    class GasEngine : Engine { }
    abstract class CarParts { }
    class Battery : CarParts { }
    class Differential : CarParts { }
    class Wheel : CarParts { }

    class Record<T1, T2>
    {
        public T1 Id { get; set; }
        public T2 Value { get; set; }

        public DateTime Date { get; set; }
    }

    public static void Main(string[] args)
    {

    }
}



