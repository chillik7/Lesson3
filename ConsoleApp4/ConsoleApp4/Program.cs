using System;
using System.Linq;
public partial class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }

    public Book(string title, string author, int pages, string genre)
    {
        Title = title;
        Author = author;
        Pages = pages;
        Genre = genre;
    }
}
public partial class Book
{
    public void PrintInfo()
    {
        Console.WriteLine($"Название: {Title}, Автор: {Author}, Страниц: {Pages}, Жанр: {Genre}");
    }
}
public class Library
{
    private Book[] books;
    public Library(Book[] books)
    {
        this.books = books ?? throw new ArgumentNullException(nameof(books));
    }
    public Book GetLongestBook()
    {
        return books.OrderByDescending(b => b.Pages).FirstOrDefault();
    }
    public Book[] GetBooksByGenre(string genre)
    {
        return books.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}
class Program
{
    static void Main()
    {
        Book[] books = {
            new Book("1984", "Джордж Оруэлл", 328, "Фантастика"),
            new Book("Преступление и наказание", "Фёдор Достоевский", 671, "Классика"),
            new Book("Мастер и Маргарита", "Михаил Булгаков", 470, "Фантастика"),
            new Book("Гарри Поттер", "Дж. К. Роулинг", 410, "Фэнтези")
        };

        Library library = new Library(books);

        Console.WriteLine("=== Список книг ===");
        foreach (var book in books)
            book.PrintInfo();

        Console.WriteLine("\n=== Самая длинная книга ===");
        Book longestBook = library.GetLongestBook();
        longestBook?.PrintInfo();

        Console.WriteLine("\n=== Книги жанра 'Фантастика' ===");
        var sciFiBooks = library.GetBooksByGenre("Фантастика");
        foreach (var book in sciFiBooks)
            book.PrintInfo();
    }
}
