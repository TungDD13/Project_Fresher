using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            Category category = new Category();
            category.Name = "Test";
            category.UrlSlug = "Test";
            category.Description = "Hello";
            
            categoryRepository.AddCategory(category);
        }
    }
}
