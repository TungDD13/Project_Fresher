using BookStore.BusinessLogicLayer.BaseServices;
using BookStore.BusinessLogicLayer.IServices;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.Repositories;
using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork, IGenericRepository<Book> repository) : base(unitOfWork, repository)
        {
        }
    }
}
