using System;

interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Обработка платежей {amount} через PayPal.");
    }
}

class StripePaymentService
{
    public void MakeTransaction(double totalAmount)
    {
        Console.WriteLine($"Обработка платежей {totalAmount} через PayPal.");
    }
}

class StripePaymentAdapter : IPaymentProcessor
{
    private readonly StripePaymentService stripePaymentService;

    public StripePaymentAdapter(StripePaymentService stripePaymentService)
    {
        this.stripePaymentService = stripePaymentService;
    }

    public void ProcessPayment(double amount)
    {
        stripePaymentService.MakeTransaction(amount);
    }
}

class SquarePaymentService
{
    public void ExecutePayment(double paymentAmount)
    {
        Console.WriteLine($"Processing payment of {paymentAmount} through Square.");
    }
}

class SquarePaymentAdapter : IPaymentProcessor
{
    private readonly SquarePaymentService squarePaymentService;

    public SquarePaymentAdapter(SquarePaymentService squarePaymentService)
    {
        this.squarePaymentService = squarePaymentService;
    }

    public void ProcessPayment(double amount)
    {
        squarePaymentService.ExecutePayment(amount);
    }
}

class Program
{
    static void Main()
    {
        IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
        paypalProcessor.ProcessPayment(100.0);

        IPaymentProcessor stripeProcessor = new StripePaymentAdapter(new StripePaymentService());
        stripeProcessor.ProcessPayment(200.0);

        IPaymentProcessor squareProcessor = new SquarePaymentAdapter(new SquarePaymentService());
        squareProcessor.ProcessPayment(300.0);
    }
}
