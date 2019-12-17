using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BookStoreContext _dbContext;

        public BookStoreContext Init() => _dbContext ?? (_dbContext = new BookStoreContext());

        protected override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
