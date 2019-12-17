using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private BookStoreContext _context;

        public BookStoreContext DbContext => _context ?? (_context = _dbFactory.Init());

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
