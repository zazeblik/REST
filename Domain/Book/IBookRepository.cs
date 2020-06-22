using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Domain.Book
{
    public interface IBookRepository : IDisposable
    {
        void Delete(int id);
        void Update(int id, string title = null, string author = null);
        void Create(Book book);
        Book GetById(int id);
        List<Book> Find(string title = null, string author = null);
    }
}
