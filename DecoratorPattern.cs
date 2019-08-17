/*
Wrapper is the alternative nickname for the Decorator pattern that clearly expresses
the main idea of the pattern. A “wrapper” is an object that can be linked with some
“target” object. The wrapper contains the same set of methods as the target and delegates
to it all requests it receives. However, the wrapper may alter the result by doing
something either before or after it passes the request to the target.
 */

using System.Collections.Generic;

namespace DecoratorPattern
{
    public abstract class Beverage
    {
        public virtual string GetDescription()
        {
            return "Beverage :";
        }
        public abstract int Cost();
    }
    public class BlackCoffee : Beverage
    {
        public override string GetDescription()
        {
            return base.GetDescription() + "BlackCoffee";
        }
        public override int Cost()
        {
            return 5;
        }
    }
    public class Cappichino : Beverage
    {
        public override string GetDescription()
        {
            return base.GetDescription() + "Cappichino";
        }
        public override int Cost()
        {
            return 10;
        }
    }
    public abstract class AddOn: Beverage
    {
        public override string GetDescription()
        {
            return base.GetDescription();
        }
    }

    public class Caramel : AddOn
    {
        Beverage b;
        public Caramel(Beverage b)
        {
            this.b = b;
        }
        public override string GetDescription()
        {
            return b.GetDescription() + " with Addon like Caramel";
        }
        public override int Cost()
        {
            return b.Cost() + 2;
        }
    }

    public class Cream : AddOn
    {
        Beverage b;
        public Cream(Beverage b)
        {
            this.b = b;
        }
        public override string GetDescription()
        {
            return b.GetDescription() + " Cream";
        }
        public override int Cost()
        {
            return b.Cost() + 1;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var coffee = new Cream(new Caramel(new Cappichino()));
            System.Console.WriteLine(coffee.GetDescription());
            System.Console.WriteLine(coffee.Cost());

            var coffee1 = new Cream(new Cappichino());
            System.Console.WriteLine(coffee1.GetDescription()); 
            System.Console.WriteLine(coffee1.Cost());

            var coffee2 = new Cappichino();
            System.Console.WriteLine(coffee2.GetDescription());
            System.Console.WriteLine(coffee2.Cost());

            var coffee3 = new Caramel(new Cappichino());
            System.Console.WriteLine(coffee3.GetDescription());
            System.Console.WriteLine(coffee3.Cost());
        }
    }
}