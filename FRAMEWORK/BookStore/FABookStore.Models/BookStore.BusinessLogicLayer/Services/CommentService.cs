using BookStore.BusinessLogicLayer.BaseServices;
using BookStore.BusinessLogicLayer.IServices;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.Repositories;
using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IGenericRepository<Comment> repository) : base(unitOfWork, repository)
        {
        }
    }
}
