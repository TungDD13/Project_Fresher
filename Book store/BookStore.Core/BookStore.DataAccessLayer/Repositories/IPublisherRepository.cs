using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BookStore.Core.Repositories
{
    public interface IPublisherRepository : IDisposable
    {
        Publisher Find(int publisherId);
        bool AddPublisher(Publisher publisher);
        bool UpdatePublisher(Publisher publisher);
        bool DeletePublisher(int PublisherId);
        bool DeletePublisher(Publisher publisher);
        List<Publisher> GetAllPublisher();
    }
}
