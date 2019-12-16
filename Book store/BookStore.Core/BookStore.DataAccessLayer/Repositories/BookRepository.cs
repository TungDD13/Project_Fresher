using System;
using System.Collections.Generic;
using System.Linq;
using FA.BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.BookStore.Core.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookContext db;
        public BookRepository(BookContext bookContext)
        {
            db = bookContext;
        }
        public bool AddBook(Book book)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CountBookByCategory(string Category)
        {
            return db.Books.Count(b => b.Categorys.CateName == Category);
        }

        public int CountBookByPublisher(string publisher)
        {
            return db.Books.Count(b => b.Publishers.PubName == publisher);
        }

        public bool DeleteBook(Book book)
        {
            try
            {
                var item = db.Books.Find(book.BookId);
                db.Books.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBook(int BookId)
        {
            try
            {
                var item = db.Books.Find(BookId);
                db.Books.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Book Find(int bookId)
        {
            return db.Books.Find(bookId);
        }

        public Book FindBookBySummary(string summary)
        {
            return db.Books.FirstOrDefault(b => b.Summary == summary);
        }

        public Book FindBookByTitle(string title)
        {
            return db.Books.FirstOrDefault(b => b.Title == title);
        }

        public List<Book> GetAllBook()
        {
            return db.Books.ToList();
        }

        public Book GetBookByCategory(string category)
        {
            return db.Books.FirstOrDefault(b => b.Categorys.CateName == category);
        }

        public Book GetBookByPublisher(string publisher)
        {
            return db.Books.FirstOrDefault(b => b.Publishers.PubName == publisher);
        }

        public List<Book> GetBooksByMonth(DateTime monthYear)
        {
            return db.Books.Where(b => b.CreateDate <= monthYear).ToList();
        }

        public List<Book> GetlatesBook(int size)
        {
            return db.Books.OrderByDescending(b => b.CreateDate).Take(size).ToList();
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
