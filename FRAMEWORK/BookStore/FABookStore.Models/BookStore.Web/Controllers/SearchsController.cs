using BookStore.BusinessLogicLayer.IServices;
using BookStore.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class SearchsController : Controller
    {
        //private readonly IAuthorService _authorService;
        //private readonly IPublisherService _publisherService;
        private BookStoreContext db = new BookStoreContext();

        //public SearchsController(
        //    IAuthorService authorService,
        //    IPublisherService publisherService
        //    )
        //{
        //    _authorService = authorService;
        //    _publisherService = publisherService;
        //}
        // GET: Identity/Search
        public ActionResult AuthorSearch()
        {
            //var syncContext = SynchronizationContext.Current;
            //SynchronizationContext.SetSynchronizationContext(null);
            //var authors = _authorService.GetAsync(orderBy: a => a.OrderBy(x => x.AuthorName)).Result;
            //SynchronizationContext.SetSynchronizationContext(syncContext);
            var authors = db.Authors.ToList();
            return PartialView(authors);
        }

        public ActionResult PublisherSearch()
        {
            //var syncContext = SynchronizationContext.Current;
            //SynchronizationContext.SetSynchronizationContext(null);
            var publishers = db.Publishers.ToList();
            //SynchronizationContext.SetSynchronizationContext(syncContext);
            return PartialView(publishers);
        }
    }
}