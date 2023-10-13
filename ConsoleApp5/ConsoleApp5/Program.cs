using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//class Program
//{
//    static void Main(string[] args)
//    {

//        Console.OutputEncoding = System.Text.Encoding.Default;
//        Console.WriteLine("Введіть перше число:");

//        double number1 = Convert.ToDouble(Console.ReadLine());

//        Console.WriteLine("Введіть друге число:");
//        double number2 = Convert.ToDouble(Console.ReadLine());

//        Console.WriteLine("Виберіть операцію: +, -, *, /");
//        char operation = Console.ReadKey().KeyChar;

//        double result = 0;

//        switch (operation)
//        {
//            case '+':
//                result = number1 + number2;
//                break;
//            case '-':
//                result = number1 - number2;
//                break;
//            case '*':
//                result = number1 * number2;
//                break;
//            case '/':
//                if (number2 != 0)
//                    result = number1 / number2;
//                else
//                    Console.WriteLine("Ділення на нуль неможливе.");
//                break;
//            default:
//                Console.WriteLine("Невірна операція.");
//                break;
//        }

//        Console.WriteLine("Результат: " + result);
//    }
//}


//class Program2
//{
//    static void Main(string[] args)
//    {
//        Console.OutputEncoding = System.Text.Encoding.Default;
//        Console.WriteLine("Введіть свій вік:");
//        int age = Convert.ToInt32(Console.ReadLine());

//        string category;

//        if (age < 0)
//        {
//            category = "Некоректний вік";
//        }
//        else if (age < 18)
//        {
//            category = "Дитина";
//        }
//        else if (age < 25)
//        {
//            category = "Підліток";
//        }
//        else
//        {
//            category = "Дорослий";
//        }

//        Console.WriteLine("Категорія віку: " + category);
//    }
//}



class Program3
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;
        Console.WriteLine("Введіть число для побудови таблиці множення:");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Таблиця множення для числа " + number + ":");

        for (int i = 1; i <= 10; i++)
        {
            int result = number * i;
            Console.WriteLine(number + " * " + i + " = " + result);
        }
    }
}


