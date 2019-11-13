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
    public class CommentsManageController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private CommentRepository _CommentRepository = new CommentRepository();

        // GET: Admin/CommentsManage
        public ActionResult Index()
        {
            var comments = _CommentRepository.GetAllComments();
            return View(comments);
        }

        // GET: Admin/CommentsManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _CommentRepository.Find(id??0);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/CommentsManage/Create
        [Authorize(Roles = "BlogOnwer")]
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            return View();
        }

        // POST: Admin/CommentsManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _CommentRepository.AddComment(comment);
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Admin/CommentsManage/Edit/5
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _CommentRepository.Find(id??0);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // POST: Admin/CommentsManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _CommentRepository.UpdateComment(comment);
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Admin/CommentsManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _CommentRepository.Find(id??0);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/CommentsManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = _CommentRepository.Find(id);
            _CommentRepository.DeleteComment(comment);
            return RedirectToAction("Index");
        }
    }
}
