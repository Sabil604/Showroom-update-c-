using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public Vehicle(string make, string model, int year, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }
}

public class Accessory : Vehicle
{
    public string AccessoryType { get; set; }

    public Accessory(string make, string model, int year, decimal price, string accessoryType)
        : base(make, model, year, price)
    {
        AccessoryType = accessoryType;
    }
}

public class Customer
{
    public string Name { get; set; }
    public string ContactNumber { get; set; }

    public Customer(string name, string contactNumber)
    {
        Name = name;
        ContactNumber = contactNumber;
    }
}

public class Loan
{
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public decimal LoanAmount { get; set; }
    public double InterestRate { get; set; }
    public int LoanTerm { get; set; } 

    public Loan(Customer customer, Vehicle vehicle, decimal loanAmount, double interestRate, int loanTerm)
    {
        Customer = customer;
        Vehicle = vehicle;
        LoanAmount = loanAmount;
        InterestRate = interestRate;
        LoanTerm = loanTerm;
    }

    public decimal CalculateMonthlyPayment()
    {
        double monthlyRate = InterestRate / 100 / 12;
        return LoanAmount * (decimal)(monthlyRate * Math.Pow(1 + monthlyRate, LoanTerm))/
               (decimal)(Math.Pow(1 + monthlyRate, LoanTerm) - 1);
    }
}
class Program
{
    static void Main(string[] args)
    {
        
        Customer customer = new Customer("Sabil Mujawar", "555");

        
        Vehicle vehicle = new Vehicle("Toyota Innova", "Grand Vitara", 2024, 30000.00m);

        
        Loan loan = new Loan(customer, vehicle, 25000.00m, 5.5, 60);

        
        Console.WriteLine($"Customer: {customer.Name}");
        Console.WriteLine($"Vehicle: {vehicle.Make} {vehicle.Model} ({vehicle.Year})");
        Console.WriteLine($"Loan Amount: {loan.LoanAmount:C}");
        Console.WriteLine($"Monthly Payment: {loan.CalculateMonthlyPayment():C}");

        
        Accessory accessory = new Accessory("Toyota Innova", "Grand Vitara", 2024, 30000.00m, "Sunroof");

       
        Console.WriteLine($"Accessory: {accessory.AccessoryType} for {accessory.Make} {accessory.Model}");
    }
}
