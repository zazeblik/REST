using REST.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST
{
    public static class BookRepository
    {
        public static BookDto DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return null;
            }
            Books = Books.Where(b => b.Id != id).ToList();
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }

        public static BookDto UpdateBook(int id, string title = null, string author = null)
        {
            Book book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return null;
            }
            if (!String.IsNullOrWhiteSpace(title))
            {
                book.Title = title;
            }
            if (!String.IsNullOrWhiteSpace(author))
            {
                book.Author = author;
            }
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }

        public static BookDto CreateBook(string title = null, string author = null)
        {
            var book = new Book{ Id = Books.Count > 0 ? Books.Max(b => b.Id) + 1 : 1, Title = title, Author = author };
            Books.Add(book);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }

        public static BookDto FindBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return null;
            }
            return new BookDto { 
                Id = book.Id,
                Author = book.Author,
                Title = book.Title
            };
        }

        public static List<BookDto> FindBooks(string title = null, string author = null)
        {
            var result = Books.Select(b => new BookDto { 
                Id = b.Id, 
                Author = b.Author, 
                Title = b.Title });
            if (!String.IsNullOrWhiteSpace(title))
            {
                result = result.Where(b => b.Title == title);
            }
            if (!String.IsNullOrWhiteSpace(author))
            {
                result = result.Where(b => b.Author == author);
            }
            return result.ToList();
        }

        private static List<Book> Books = new List<Book>();

        private class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }
    }
}

