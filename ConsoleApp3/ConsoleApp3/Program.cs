using System;
using System.Linq;
abstract class Book
{
    public string Title { get; }
    public string Author { get; }
    public int Pages { get; }
    protected Book(string title, string author, int pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }
    public override string ToString()
    {
        return $"{Title} by {Author}, {Pages} pages";
    }
}
sealed class FictionBook : Book
{
    public FictionBook(string title, string author, int pages) : base(title, author, pages) { }
}
sealed class NonFictionBook : Book
{
    public NonFictionBook(string title, string author, int pages) : base(title, author, pages) { }
}
class Library
{
    private Book[] books;
    public Library(Book[] books)
    {
        this.books = books;
    }
    public Book GetMostPagesBook()
    {
        return books.OrderByDescending(b => b.Pages).FirstOrDefault();
    }
    public Book[] GetBooksByAuthor(string author)
    {
        return books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}
class Program
{
    static void Main()
    {
        Book[] books = {
            new FictionBook("Dune", "Frank Herbert", 500),
            new FictionBook("1984", "George Orwell", 328),
            new NonFictionBook("Sapiens", "Yuval Noah Harari", 450),
            new NonFictionBook("Educated", "Tara Westover", 400),
            new FictionBook("Brave New World", "Aldous Huxley", 350)
        };

        Library library = new Library(books);

        Console.WriteLine("Книга с наибольшим количеством страниц:");
        Console.WriteLine(library.GetMostPagesBook());

        Console.Write("\nВведите автора для поиска книг: ");
        string author = Console.ReadLine();
        var authorBooks = library.GetBooksByAuthor(author);

        if (authorBooks.Length > 0)
        {
            Console.WriteLine($"Книги автора {author}:");
            foreach (var book in authorBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine($"Нет книг автора {author}.");
        }
    }
}
