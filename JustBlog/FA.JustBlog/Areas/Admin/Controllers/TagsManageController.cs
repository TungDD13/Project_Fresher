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
    [Authorize]
    public class TagsManageController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private TagRepository _tagRepository = new TagRepository();

        // GET: Admin/TagsManage
        public ActionResult Index()
        {
            return View(_tagRepository.GetAllTags());
        }

        // GET: Admin/TagsManage/Details/5
        public ActionResult Details(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.Find(name);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Admin/TagsManage/Create
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TagsManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Count,UrlSlug,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.AddTag(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Admin/TagsManage/Edit/5
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Edit(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.Find(name);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admin/TagsManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Count,UrlSlug,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.UpdateTag(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Admin/TagsManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.Find(name);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admin/TagsManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tag tag = db.Tags.Find(id);
            _tagRepository.DeleteTag(tag);
            return RedirectToAction("Index");
        }
    }
}
