using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CategoriesManageController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private CategoryRepository _categoryRepository = new CategoryRepository();

        // GET: Admin/CategoriesManage
        public ActionResult Index()
        {
            return View(_categoryRepository.GetAllCategories());
        }

        // GET: Admin/CategoriesManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryRepository.Find(id??0);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/CategoriesManage/Create
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoriesManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UrlSlug,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/CategoriesManage/Edit/5
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryRepository.Find(id??0);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoriesManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UrlSlug,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/CategoriesManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryRepository.Find(id??0);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoriesManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _categoryRepository.Find(id);
            _categoryRepository.DeleteCategory(category);
            return RedirectToAction("Index");
        }

    }
}
