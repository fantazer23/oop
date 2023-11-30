using System;
using System.Collections.Generic;
using System.IO;

// Базовий абстрактний клас Product
public abstract class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public abstract double CalculateTotalPrice(int quantity);
}

// Клас-спадкоємець Electronics
public class Electronics : Product
{
    public Electronics(string name, double price) : base(name, price) { }

    public override double CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// Клас-спадкоємець Clothing
public class Clothing : Product
{
    public Clothing(string name, double price) : base(name, price) { }

    public override double CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// Клас-спадкоємець Books
public class Books : Product
{
    public Books(string name, double price) : base(name, price) { }

    public override double CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// Клас для вибору товарів та їх кількостей, введення адреси доставки і розрахунку загальної вартості
public class Shopping
{
    public static event EventHandler<string> PaymentEvent;

    public static void Main(string[] args)
    {
        Dictionary<Product, int> cart = new Dictionary<Product, int>();
        Electronics phone = new Electronics("Phone", 500);
        Clothing shirt = new Clothing("Shirt", 30);
        Books book = new Books("Book", 15);

        cart.Add(phone, 2);
        cart.Add(shirt, 3);
        cart.Add(book, 5);

        double totalCost = 0;
        Console.WriteLine("Selected Products:");
        foreach (var item in cart)
        {
            Console.WriteLine($"Product: {item.Key.Name}, Quantity: {item.Value}, Price: ${item.Key.CalculateTotalPrice(item.Value)}");
            totalCost += item.Key.CalculateTotalPrice(item.Value);
        }

        Console.WriteLine("\nEnter delivery address:");
        string address = Console.ReadLine();

        SaveProductsToFile(cart); // Збереження товарів у файл

        Console.WriteLine($"\nTotal Cost: ${totalCost}");
        Console.WriteLine($"Delivery Address: {address}");

        SelectPaymentMethod(totalCost); // Вибір методу оплати та розрахунок вартості з комісією
    }

    // Функція для збереження товарів у файл
    public static void SaveProductsToFile(Dictionary<Product, int> cart)
    {
        using (StreamWriter writer = new StreamWriter("products.txt"))
        {
            foreach (var item in cart)
            {
                writer.WriteLine($"{item.Key.Name},{item.Key.Price},{item.Value}");
            }
        }
    }

    // Функція для вибору методу оплати та розрахунку вартості з комісією
    public static void SelectPaymentMethod(double totalCost)
    {
        Console.WriteLine("\nSelect Payment Method (1 - Credit Card, 2 - PayPal):");
        int paymentMethod = Convert.ToInt32(Console.ReadLine());

        double commission = 0;
        if (paymentMethod == 1)
        {
            commission = totalCost * 0.02; // Комісія за кредитною карткою
        }
        else if (paymentMethod == 2)
        {
            commission = totalCost * 0.03; // Комісія за PayPal
        }

        totalCost += commission;
        Console.WriteLine($"Total Cost with Commission: ${totalCost}");

        OnPaymentEvent($"Payment completed with method: {(paymentMethod == 1 ? "Credit Card" : "PayPal")}");
    }

    // Виклик події про оплату
    protected static void OnPaymentEvent(string message)
    {
        PaymentEvent?.Invoke(null, message);
    }
}
