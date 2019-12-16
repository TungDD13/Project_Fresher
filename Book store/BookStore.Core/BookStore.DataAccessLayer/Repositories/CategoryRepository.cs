using FA.BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.BookStore.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private BookContext db;

        public CategoryRepository(BookContext bookContext)
        {
            db = bookContext;
        }
        public bool AddCategory(Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                var item = db.Categories.Find(category.CateId);
                //var item1 = db.Categories.FirstOrDefault(c=>c.CateName.Equals( category.CateName));
                db.Categories.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var item = db.Categories.Find(categoryId);
                db.Categories.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Category Find(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public List<Category> GetAllCategory()
        {
            return db.Categories.ToList();
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<Category> FindAsync(int categoryId)
        {
            return await db.Categories.FindAsync(categoryId);
        }

        async Task<Category> ICategoryRepository.FindAsync(object categoryId)
        {
            return await db.Categories.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
