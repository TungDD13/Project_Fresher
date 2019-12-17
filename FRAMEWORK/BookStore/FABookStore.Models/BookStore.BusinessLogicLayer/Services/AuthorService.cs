using BookStore.BusinessLogicLayer.BaseServices;
using BookStore.BusinessLogicLayer.IServices;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.Repositories;
using FABookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork, IGenericRepository<Author> repository) : base(unitOfWork, repository)
        {
        }
    }
}
