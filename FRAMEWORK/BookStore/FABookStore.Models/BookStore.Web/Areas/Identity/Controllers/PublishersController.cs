using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.BusinessLogicLayer.IServices;
using BookStore.DataAccessLayer;
using FA.BookStore.Core.Models;

namespace BookStore.Web.Areas.Identity.Controllers
{
    public class PublishersController : Controller
    {
        //private BookStoreContext db = new BookStoreContext();

        private readonly IPublisherService _publisherService;

        public PublishersController()
        {

        }
        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: Identity/Publishers
        public ActionResult Index()
        {
            return View(_publisherService.GetAll());
        }

        //// GET: Identity/Publishers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Publisher publisher = db.Publishers.Find(id);
        //    if (publisher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(publisher);
        //}

        //// GET: Identity/Publishers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Identity/Publishers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PublisherId,PublisherName,Description")] Publisher publisher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Publishers.Add(publisher);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(publisher);
        //}

        //// GET: Identity/Publishers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Publisher publisher = db.Publishers.Find(id);
        //    if (publisher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(publisher);
        //}

        //// POST: Identity/Publishers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PublisherId,PublisherName,Description")] Publisher publisher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(publisher).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(publisher);
        //}

        //// GET: Identity/Publishers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Publisher publisher = db.Publishers.Find(id);
        //    if (publisher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(publisher);
        //}

        //// POST: Identity/Publishers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Publisher publisher = db.Publishers.Find(id);
        //    db.Publishers.Remove(publisher);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
