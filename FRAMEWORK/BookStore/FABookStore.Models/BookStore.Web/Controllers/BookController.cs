using BookStore.BusinessLogicLayer.IServices;
using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookServices;
        private readonly ICommentService _commentServices;

        public BookController(
            IBookService bookServices,
            ICommentService commentServices
            )
        {
            _bookServices = bookServices;
            _commentServices = commentServices;
        }
        // GET: Book
        public async Task<ActionResult> Index()
        {
            var books = await _bookServices.GetAsync(filter: b => b.IsActive == true, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 12);

            return View(books);
        }
    }
}