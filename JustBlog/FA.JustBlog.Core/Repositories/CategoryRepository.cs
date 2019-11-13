using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly JustBlogContext db;

        public CategoryRepository()
        {
            db = new JustBlogContext();
        }
        
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            var item = db.Categories.Find(category.Id);
            db.Categories.Remove(item);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var item = db.Categories.Find(categoryId);
            db.Categories.Remove(item);
            db.SaveChanges();
        }

        public Category Find(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public IList<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
