using System;

interface Beverage
{
    string Description { get; }
    double Cost();
}

class Espresso : Beverage
{
    public string Description => "Espresso";
    public double Cost() => 50.0;
}

class Tea : Beverage
{
    public string Description => "Tea";
    public double Cost() => 30.0;
}

class Latte : Beverage
{
    public string Description => "Latte";
    public double Cost() => 70.0;
}

class Mocha : Beverage
{
    public string Description => "Mocha";
    public double Cost() => 80.0;
}

abstract class BeverageDecorator : Beverage
{
    protected Beverage beverage;
    public BeverageDecorator(Beverage beverage) { this.beverage = beverage; }
    public virtual string Description => beverage.Description;
    public abstract double Cost();
}

class Milk : BeverageDecorator
{
    public Milk(Beverage beverage) : base(beverage) { }
    public override string Description => beverage.Description + ", Milk";
    public override double Cost() => beverage.Cost() + 10.0;
}

class Sugar : BeverageDecorator
{
    public Sugar(Beverage beverage) : base(beverage) { }
    public override string Description => beverage.Description + ", Sugar";
    public override double Cost() => beverage.Cost() + 5.0;
}

class WhippedCream : BeverageDecorator
{
    public WhippedCream(Beverage beverage) : base(beverage) { }
    public override string Description => beverage.Description + ", Whipped Cream";
    public override double Cost() => beverage.Cost() + 15.0;
}

class Syrup : BeverageDecorator
{
    public Syrup(Beverage beverage) : base(beverage) { }
    public override string Description => beverage.Description + ", Syrup";
    public override double Cost() => beverage.Cost() + 20.0;
}

class Program
{
    static void Main()
    {
        Beverage beverage = new Espresso();
        beverage = new Milk(beverage);
        beverage = new Sugar(beverage);
        beverage = new WhippedCream(beverage);
        Console.WriteLine($"{beverage.Description}: {beverage.Cost()}");

        Beverage beverage2 = new Latte();
        beverage2 = new Syrup(beverage2);
        beverage2 = new Milk(beverage2);
        Console.WriteLine($"{beverage2.Description}: {beverage2.Cost()}");

        Beverage beverage3 = new Mocha();
        beverage3 = new WhippedCream(beverage3);
        beverage3 = new Sugar(beverage3);
        beverage3 = new Syrup(beverage3);
        Console.WriteLine($"{beverage3.Description}: {beverage3.Cost()}");
    }
}
