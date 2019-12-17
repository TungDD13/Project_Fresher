using BookStore.BusinessLogicLayer.BaseServices;
using BookStore.BusinessLogicLayer.IServices;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class PublisherService : BaseService<Publisher>, IPublisherService
    {
        public PublisherService(IUnitOfWork unitOfWork, IGenericRepository<Publisher> repository) : base(unitOfWork, repository)
        {
        }
    }
}
