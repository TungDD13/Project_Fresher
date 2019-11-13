using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private JustBlogContext db = new JustBlogContext();
        private CategoryRepository categoryRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        [ChildActionOnly]
        public ActionResult getCategory()
        {
            
            var listCategory = categoryRepository.GetAllCategories();
            return PartialView("_PopularCategorys", listCategory);
        }
    }
}