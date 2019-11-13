using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using NUnit.Framework;


namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class CategoryTest
    {
        private ICategoryRepository categoryRepository = new CategoryRepository();
        [Test]
        public void TestAddCategory()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            Category category = new Category();
            category.Name = "Entity Framework";
            category.UrlSlug = "Entity Framework";
            category.Description = "All posts in Entity Framework category";

            categoryRepository.AddCategory(category);
            Assert.That(1 == 1);
        }
    }
}
