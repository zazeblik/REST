using Microsoft.EntityFrameworkCore;
using REST.Domain.Book;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BooksContext db;
        public BookRepository(BooksContext booksContext)
        {
            db = booksContext;
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public void Update(int id, string title = null, string author = null)
        {
            Book book = db.Books.Find(id);
            if (book == null) return;
            book.SetTitle(title);
            book.SetAuthor(author);
        }

        public List<Book> Find(string title = null, string author = null)
        {
            var query = db.Books.AsQueryable();
            if (title != null)
            {
                query = query.Where(x => x.Title == title);
            }
            if (author != null)
            {
                query = query.Where(x => x.Author == author);
            }
            return query.ToList();
        }

        public Book GetById(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }


        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
