using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankAccount
{
    // Властивості
    public string AccountNumber { get; private set; }  // Номер рахунку
    public double Balance { get; private set; }        // Баланс

    // Конструктор
    public BankAccount(string accountNumber, double initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    // Метод для поповнення рахунку на задану суму
    public void ПоповнитиРахунок(double AMOUNT)
    {
        if (AMOUNT > 0)
        {
            Balance += AMOUNT;
        }
        else
        {
            Console.WriteLine("Сума поповнення повинна бути більшою за нуль.");
        }
    }

    // Метод для зняття грошей з рахунку
    public void ЗнятиГроші(double AMOUNT)
    {
        if (AMOUNT > 0 && Balance >= AMOUNT)
        {
            Balance -= AMOUNT;
        }
        else if (AMOUNT <= 0)
        {
            Console.WriteLine("Сума зняття повинна бути більшою за нуль.");
        }
        else
        {
            Console.WriteLine("Недостатньо коштів на рахунку для зняття.");
        }
    }

    // Метод для виведення інформації про рахунок (номер та баланс)
    public void ПоказатиІнформацію()
    {
        Console.OutputEncoding = System.Text.Encoding.Default;
        Console.WriteLine("Інформація про рахунок:");
        Console.WriteLine("Номер рахунку: " + AccountNumber);
        Console.WriteLine("Поточний баланс: " + Balance);
    }

}
class Program
{
   static void Main(string[] args)
    {
        // Створення об'єкту класу "Банківський рахунок"
        BankAccount account = new BankAccount("1231231241", 100);
        account.ПоповнитиРахунок(500);
        account.ЗнятиГроші(300);
        account.ПоказатиІнформацію();
    }

}