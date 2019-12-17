using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BookStoreContext Init();
    }
}
