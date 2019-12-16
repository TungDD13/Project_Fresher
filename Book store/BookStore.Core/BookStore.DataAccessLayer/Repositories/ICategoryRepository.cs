using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BookStore.Core.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        Category Find(int categoryId);
        Task<Category> FindAsync(object categoryId);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        bool DeleteCategory(Category category);
        List<Category> GetAllCategory();
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
