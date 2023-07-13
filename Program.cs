using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{
    class BookManagementApp
    {
        private LinkedList<Book> books = new LinkedList<Book>();
        public void AddBook(string title, string author, string genre, int year)
        {
            Book book = new Book(title, author, genre, year);
            books.AddLast(book);
        }
        public void RemoveBook(string title)
        {
            LinkedListNode<Book> node = FindBook(title);
            if (node != null)
            {
                books.Remove(node);
            }
            else
            {
                Console.WriteLine("Книга з такою назвою не знайдена.");
            }
        }
        public void UpdateBook(string title, string newTitle, string newAuthor, string newGenre, int newYear)
        {
            LinkedListNode<Book> node = FindBook(title);
            if (node != null)
            {
                Book book = node.Value;
                book.Title = newTitle;
                book.Author = newAuthor;
                book.Genre = newGenre;
                book.Year = newYear;
            }
            else
            {
                Console.WriteLine("Книга з такою назвою не знайдена.");
            }
        }
        public List<Book> SearchBooks(string keyword)
        {
            List<Book> searchResults = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Title.Contains(keyword) ||
                    book.Author.Contains(keyword) ||
                    book.Genre.Contains(keyword) ||
                    book.Year.ToString().Contains(keyword))
                {
                    searchResults.Add(book);
                }
            }

            return searchResults;
        }
        public void InsertAtBeginning(string title, string author, string genre, int year)
        {
            Book book = new Book(title, author, genre, year);
            books.AddFirst(book);
        }
        public void InsertAtEnd(string title, string author, string genre, int year)
        {
            Book book = new Book(title, author, genre, year);
            books.AddLast(book);
        }
        public void InsertAtPosition(string title, string author, string genre, int year, int position)
        {
            LinkedListNode<Book> node = books.First;
            int currentPosition = 1;

            while (node != null && currentPosition < position)
            {
                node = node.Next;
                currentPosition++;
            }

            if (node != null)
            {
                Book book = new Book(title, author, genre, year);
                books.AddBefore(node, book);
            }
            else
            {
                Console.WriteLine("Позиція вставки перевищує розмір списку.");
            }
        }
        public void RemoveFromBeginning()
        {
            if (books.Count > 0)
            {
                books.RemoveFirst();
            }
            else
            {
                Console.WriteLine("Список книг порожній.");
            }
        }
        public void RemoveFromEnd()
        {
            if (books.Count > 0)
            {
                books.RemoveLast();
            }
            else
            {
                Console.WriteLine("Список книг порожній.");
            }
        }
        public void RemoveFromPosition(int position)
        {
            if (position >= 1 && position <= books.Count)
            {
                LinkedListNode<Book> node = books.First;
                int currentPosition = 1;

                while (currentPosition < position)
                {
                    node = node.Next;
                    currentPosition++;
                }

                books.Remove(node);
            }
            else
            {
                Console.WriteLine("Неприпустима позиція для видалення.");
            }
        }
        public void PrintBooks()
        {
            Console.WriteLine("Список книг:");
            foreach (Book book in books)
            {
                Console.WriteLine("Назва: {0}", book.Title);
                Console.WriteLine("Автор: {0}", book.Author);
                Console.WriteLine("Жанр: {0}", book.Genre);
                Console.WriteLine("Рік видання: {0}", book.Year);
                Console.WriteLine();
            }
        }
        private LinkedListNode<Book> FindBook(string title)
        {
            foreach (Book book in books)
            {
                if (book.Title == title)
                {
                    return books.Find(book);
                }
            }
            return null;
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }
    }

    class Programl
    {
        static void Main(string[] args)
        {
            BookManagementApp app = new BookManagementApp();

            app.AddBook("Book1", "Author1", "Genre1", 2021);
            app.AddBook("Book2", "Author2", "Genre2", 2022);
            app.AddBook("Book3", "Author3", "Genre3", 2023);

            app.PrintBooks();

            app.UpdateBook("Book2", "UpdatedBook2", "UpdatedAuthor2", "UpdatedGenre2", 2024);

            app.PrintBooks();

            app.RemoveBook("Book3");

            app.PrintBooks();

            List<Book> searchResults = app.SearchBooks("Author");
            Console.WriteLine("Результати пошуку за ключовим словом 'Author':");
            foreach (Book book in searchResults)
            {
                Console.WriteLine(book.Title);
            }

            app.InsertAtBeginning("NewBook", "NewAuthor", "NewGenre", 2025);

            app.PrintBooks();

            app.InsertAtEnd("NewestBook", "NewestAuthor", "NewestGenre", 2026);

            app.PrintBooks();

            app.InsertAtPosition("InsertedBook", "InsertedAuthor", "InsertedGenre", 2027, 2);

            app.PrintBooks();

            app.RemoveFromBeginning();

            app.PrintBooks();

            app.RemoveFromEnd();

            app.PrintBooks();

            app.RemoveFromPosition(2);

            app.PrintBooks();
        }
    }
}
