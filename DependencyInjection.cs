/*
Dependency injection using Unity framework.
Demo shows property Injection as well constructor injection
 */
 using System;
using Unity;

namespace IteratorOne
{
    //IEnumerable and IEnumerator

    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>("LuxuryCar");

            var driver = container.Resolve<Driver>();
            var driver1 = container.Resolve<DriverPropertyInjection>();
            driver.RunCar();
            driver1.RunCar();
        }
    }
    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Ford : ICar
    {
        private int _miles = 0;
        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }
    public class Driver
    {
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
    /// <summary>
    /// Property Injection
    /// </summary>
    public class DriverPropertyInjection
    {
        public DriverPropertyInjection()
        {
        }

        [Dependency("LuxuryCar")]
        public ICar Car { get; set; }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", this.Car.GetType().Name, this.Car.Run());
        }
    }
}
