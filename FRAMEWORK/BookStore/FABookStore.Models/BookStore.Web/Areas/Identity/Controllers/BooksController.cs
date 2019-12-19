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
    public class BooksController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Identity/Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Identity/Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Identity/Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName");
            return View();
        }

        // POST: Identity/Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,CategoryId,AuthorId,PublisherId,Summary,ImgUrl,Price,Quantity,CreateDate,ModifieDate,IsActive")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Identity/Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // POST: Identity/Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,CategoryId,AuthorId,PublisherId,Summary,ImgUrl,Price,Quantity,CreateDate,ModifieDate,IsActive")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Identity/Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Identity/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
