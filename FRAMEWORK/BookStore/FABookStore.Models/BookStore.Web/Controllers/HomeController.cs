using BookStore.BusinessLogicLayer.IServices;
using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookServices;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentServices;
        //private readonly IAuthorService _authorService;
        //private readonly IPublisherService _publisherService;

        public HomeController(
            IBookService bookServices,
            //IAuthorService authorService,
            ICategoryService categoryService,
            //IPublisherService publisherService,
            ICommentService commentServices
            )
        {
            _bookServices = bookServices;
            _commentServices = commentServices;
            _categoryService = categoryService;
            //_authorService = authorService;
            //_publisherService = publisherService;
        }
        // GET: Book
        //public async Task<ActionResult> Index()
        //{
        //    var books = await _bookServices.GetAsync(filter: b => b.IsActive == true, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 12);

        //    return View(books);
        //}

            public async Task<ActionResult> Index(string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrWhiteSpace(sortOrder) ? "name_desc" : "";
            ViewData["TotalSortParm"] = sortOrder == "Total" ? "total_desc" : "Total";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Category, bool>> filter = null;
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = a => a.CategoryName.Contains(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = b => b.OrderByDescending(s => s.CategoryName);
                    break;
                case "Total":
                    orderBy = b => b.OrderBy(s => s.Books.Count());
                    break;
                case "total_desc":
                    orderBy = b => b.OrderByDescending(s => s.Books.Count());
                    break;
                default:
                    orderBy = b => b.OrderBy(s => s.CategoryName);
                    break;
            }

            var categories = await _categoryService.GetAsync(filter: filter, orderBy: orderBy, page: page ?? 1, pageSize: 10);

            return View(categories);
        }

        public async Task<ActionResult> DetailPublisher(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var books = await _bookServices.GetAsync(filter: b => b.Publisher.PublisherId == id, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        public async Task<ActionResult> Detailauthor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var books = await _bookServices.GetAsync(filter: b => b.Author.AuthorId == id, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}