using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;
        Console.WriteLine("Введіть координату x:");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Некоректне значення для x.");
            return;
        }

        Console.WriteLine("Введіть координату y:");
        if (!double.TryParse(Console.ReadLine(), out double y))
        {
            Console.WriteLine("Некоректне значення для y.");
            return;
        }

        string quadrant = DetermineQuadrant(x, y);
        Console.WriteLine("Точка знаходиться в {0} чверті.", quadrant);

        // Візуальне відображення точки на графіку (консоль)
        DisplayPointOnGraph(x, y);
        Console.ReadLine(); // Чекаємо натискання клавіші перед закриттям програми
    }

    static string DetermineQuadrant(double x, double y)
    {
        if (x > 0 && y > 0)
        {
        return "першій";
        }
        else if (x < 0 && y > 0)
        {
              return "другій";
        }
        else if (x < 0 && y < 0)
        {
                  return "третій";
        }
        else if (x > 0 && y < 0)
        {         
            return "четвертій";
        }
        else
        {     
            return "вихід за межі";
        }
    }
    static void DisplayPointOnGraph(double x, double y)
    {
        Console.WriteLine("Точка з координатами ({0}, {1}).", x, y);
    }
}

