using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.BookStore.Core.Models;
using FA.BookStore.Core.Repositories;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BookStore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;
        private readonly IBookRepository _repository;

        public BooksController(BookContext context, IBookRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(_repository.GetAllBook());
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _repository.Find(id??0);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CateName");
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create( Book book, IFormFile Image, IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                //Image = formCollection["UploadedImage"].ToArray();
                //using (var ms = new MemoryStream())
                //{
                //    Image.CopyTo(ms);
                //    book.ImgUrl = ms.ToArray();
                //}


                ////---------------
                _repository.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CateName", book.CateId);
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubName", book.PubId);
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _repository.Find(id??0);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CateName", book.CateId);
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubName", book.PubId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BookId,Title,CateId,AuthorId,PubId,Summary,ImgUrl,Price,Quantity,CreateDate,ModifieDate,IsActive")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CateName", book.CateId);
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubName", book.PubId);
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _repository.Find(id??0);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
