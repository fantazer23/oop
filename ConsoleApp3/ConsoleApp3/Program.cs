using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PalindromeChecker
{
    private string word;
    public PalindromeChecker(string inputWord)
    {
        word = inputWord;
    }

    public bool IsPalindrome()

    {

        // Перетворюємо слово на рядок у нижньому регістрі і видаляємо символи розділення.

        string cleanedWord = string.Join("", word.ToLower().Split());

        // Порівнюємо слово із його реверснутим варіантом.

        return cleanedWord == new string(cleanedWord.ToCharArray().Reverse().ToArray());

            // Цей метод видаляє з рядка всі символи, які не є літерами або цифрами.
        string RemoveNonAlphanumeric(string input)
        {

            //  об'єкт  для зберігання результуючого рядка без неалфанумеричних символів.
            StringBuilder result = new StringBuilder();

            // Перебираємо кожен символ у введеному рядку.
            foreach (char c in input)
            {
                // Якщо символ є літерою або цифрою, додаємо його до результату.
                if (char.IsLetterOrDigit(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

            // Цей метод реверсує рядок, тобто переставляє символи у зворотньому порядку.
          string ReverseString(string input)
        {
            // Перетворюємо рядок на масив символів.
            char[] charArray = input.ToCharArray();

            // Реверсуємо порядок елементів у масиві.
            Array.Reverse(charArray);

            // Повертаємо рядок, створений з реверсованого масиву символів.
            return new string(charArray);
        }
    }
}



class Program
{
    static void Main()

    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть слово для перевірки на паліндром: ");

        string userInput = Console.ReadLine();

        PalindromeChecker checker = new PalindromeChecker(userInput);

        if (checker.IsPalindrome())
        {
            Console.WriteLine($"{userInput} - це паліндром!");
        }
        else
        {
            Console.WriteLine($"{userInput} - це не паліндром.");
        }
    }
}