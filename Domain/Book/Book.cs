using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Domain.Book
{
    public class Book
    {
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetAuthor(string title)
        {
            Title = title;
        }
    }
}
