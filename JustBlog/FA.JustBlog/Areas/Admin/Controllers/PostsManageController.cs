using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core.Models;
using IdentitySample.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    //[Authorize(Roles = "BlogOnwer, Contributor")]
    public class PostsManageController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private TagRepository _tagRepository = new TagRepository();
        private PostRepository postRepository;

        public PostsManageController()
        {
            postRepository = new PostRepository();
        }

        // GET: Admin/PostsManage
        public ActionResult Index()
        {
            ViewBag.ViewPost = "All post!";
            var posts = postRepository.GetAllPosts().ToList();
            return View(posts);
        }

        public ActionResult MostViewedPost()
        {
            ViewBag.ViewPost = "Most viewed posts!";
            var mostViewedPosts = postRepository.GetMostViewedPost(2);
            //// Map from Post model to PostSummary view model

            return View("Index", mostViewedPosts);
        }
        public ActionResult LatestPosts()
        {
            ViewBag.ViewPost = "Latest posts!";
            var latestPosts = postRepository.GetLatestPost(2);
            return View("Index", latestPosts);
        }

        public ActionResult PublishedPosts()
        {
            ViewBag.ViewPost = "Publised posts!";
            var listPost = postRepository.GetPublisedPosts();
            return View("Index", listPost);
        }

        public ActionResult UnpublishedPosts()
        {
            ViewBag.ViewPost = "Un Publised posts!";
            var listPost = postRepository.GetUnpublisedPosts();
            return View("Index", listPost);
        }

        // GET: Admin/PostsManage/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Post post = postRepository.FindPost(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/PostsManage/Create
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.listTag = _tagRepository.GetAllTags();
            return View();
        }

        // POST: Admin/PostsManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,PostContent,Meta,UrlSlug,Published,PostedOn,Modified,CategoryId,ViewCount,RateCount,TotalRate")] Post post,string listTag,FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                post.TagValues = formCollection["listTag"];
                postRepository.AddPost(post);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Admin/PostsManage/Edit/5
        [Authorize(Roles = "BlogOnwer, Contributor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postRepository.FindPost(id ?? 0);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.listTag = _tagRepository.GetAllTags();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Admin/PostsManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "BlogOnwer, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,PostContent,Meta,UrlSlug,Published,PostedOn,Modified,CategoryId,ViewCount,RateCount,TotalRate")] Post post, string listTag, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                post.TagValues = formCollection["listTag"];
                postRepository.UpdatePost(post);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Admin/PostsManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postRepository.FindPost(id ?? 0);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/PostsManage/Delete/5
        [Authorize(Roles = "BlogOnwer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = postRepository.FindPost(id);
            postRepository.DeletePost(post);
            return RedirectToAction("Index");
        }

    }
}
