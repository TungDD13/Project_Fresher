using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FA.BookStore.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class SideBarController : Controller
    {
        private readonly ICategoryRepository _CategoryRepository;

        public SideBarController(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        public IActionResult SideBarCategory()
        {
            var listCategory = _CategoryRepository.GetAllCategory();
            return View(listCategory);
        }
    }
}