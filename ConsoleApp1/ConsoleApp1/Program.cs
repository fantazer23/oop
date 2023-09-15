using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

// Клас, який представляє книгу
class Book
{
    public string Title { get; set; } 
    public string Author { get; set; } 
    public int Year { get; set; } 

    // Конструктор для  властивостей книги
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    // метод для представлення об'єкта книги у вигляді рядка
    public override string ToString()
    {
        return $"Назва: {Title}, Автор: {Author}, Рік видання: {Year}";
    }
}

// Клас, який представляє бібліотеку
class Library
{
    private List<Book> books; // Список книг у бібліотеці

    // Конструктор для бібліотеки
    public Library()
    {
        books = new List<Book>();
    }

    // Метод для додавання книги до бібліотеки
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Книгу додано до бібліотеки.");
    }

    // Метод для видалення книги з бібліотеки за назвою
    public void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Книгу видалено з бібліотеки.");
        }
        else
        {
            Console.WriteLine("Книгу з вказаною назвою не знайдено.");
        }
    }

    // Метод для пошуку книг за автором
    public List<Book> SearchByAuthor(string author)
    {
        return books.FindAll(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
    }

    // Метод для пошуку книг за назвою
    public List<Book> SearchByTitle(string title)
    {
        return books.FindAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    // Метод для виведення всіх книг у бібліотеці
    public void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Бібліотека порожня.");
            return;
        }

        Console.WriteLine("Книги в бібліотеці:");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

// Головний клас програми
class Program
{
    private static Library library = new Library(); // Створення об'єкту бібліотеки

    // Головний метод програми
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Додати книгу");
            Console.WriteLine("2. Видалити книгу");
            Console.WriteLine("3. Пошук книги за автором");
            Console.WriteLine("4. Пошук книги за назвою");
            Console.WriteLine("5. Показати всі книги");
            Console.WriteLine("6. Вийти");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    SearchByAuthor();
                    break;
                case "4":
                    SearchByTitle();
                    break;
                case "5":
                    DisplayAllBooks();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Метод для додавання книги
    private static void AddBook()
    {
        Console.Write("Введіть назву книги: ");
        string title = Console.ReadLine();

        Console.Write("Введіть автора книги: ");
        string author = Console.ReadLine();

        Console.Write("Введіть рік видання: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Неправильний формат для року видання. Будь ласка, введіть ціле число.");
            return;
        }

        Book book = new Book(title, author, year);
        library.AddBook(book);
    }

    // Метод для видалення книги
    private static void RemoveBook()
    {
        Console.Write("Введіть назву книги для видалення: ");
        string title = Console.ReadLine();

        library.RemoveBook(title);
    }

    // Метод для пошуку книг за автором
    private static void SearchByAuthor()
    {
        Console.Write("Введіть автора для пошуку: ");
        string author = Console.ReadLine();

        var booksByAuthor = library.SearchByAuthor(author);

        if (booksByAuthor.Count > 0)
        {
            Console.WriteLine($"Знайдено книг автора '{author}':");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine($"Книги автора '{author}' не знайдено.");
        }
    }

    // Метод для пошуку книг за назвою
    private static void SearchByTitle()
    {
        Console.Write("Введіть назву для пошуку: ");
        string title = Console.ReadLine();

        var booksByTitle = library.SearchByTitle(title);

        if (booksByTitle.Count > 0)
        {
            Console.WriteLine($"Знайдено книг з назвою, що містить '{title}':");
            foreach (var book in booksByTitle)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine($"Книги з назвою, що містить '{title}', не знайдено.");
        }
    }

    // Метод для виведення всіх книг у бібліотеці
    private static void DisplayAllBooks()
    {
        library.DisplayAllBooks();
    }
}
