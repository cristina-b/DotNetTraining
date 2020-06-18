using System;
using System.Collections.Generic;

namespace SingleResponsibilityBooksAfter
{
    public class BookManager<T>
    {
        public List<Book> Book = new List<Book>();

        internal void Add(Book book1)
        {
            Book.Add(book1);
        }
    }
}