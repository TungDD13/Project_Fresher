using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BookStore.Core.Repositories
{
    public interface IBookRepository : IDisposable
    {
        Book Find(int bookId);
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int BookId);
        bool DeleteBook(Book book);
        List<Book> GetAllBook();
        Book FindBookByTitle(string title);
        Book FindBookBySummary(string summary);
        List<Book> GetlatesBook(int size);
        List<Book> GetBooksByMonth(DateTime monthYear);
        int CountBookByCategory(string Category);
        Book GetBookByCategory(string category);
        int CountBookByPublisher(string publisher);
        Book GetBookByPublisher(string publisher);

    }
}
