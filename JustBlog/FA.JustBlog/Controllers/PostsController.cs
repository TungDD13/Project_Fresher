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
using Microsoft.AspNet.Identity;

namespace FA.JustBlog.Controllers
{
    public class PostsController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private PostRepository postRepository;
        private CategoryRepository categoryRepository;
        private CommentRepository _CommentRepository = new CommentRepository();

        public PostsController()
        {
            postRepository = new PostRepository();
            categoryRepository = new CategoryRepository();
        }

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Category).ToList();
            return View(posts);
        }

        public ActionResult getPostByCategory(string category)
        {
            ViewBag.postName = category;
            var posts = postRepository.GetPostsByCategory(category).ToList();
            return View("Index", posts);
        }

        public ActionResult searchPost(string keySearch="")
        {

            var posts = db.Posts.Where(p => p.Title.Contains(keySearch)).ToList();
            return View("Index", posts);
        }

        public ActionResult getPostByTag(string tagName)
        {
            ViewBag.tagName = tagName;
            var posts = postRepository.GetPostsByTag(tagName).ToList();
            return View("Index", posts);
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

        [ChildActionOnly]
        public PartialViewResult MostViewedPost()
        {
            ViewBag.PartialName = "Most viewed posts!";
            var mostViewedPosts = postRepository.GetMostViewedPost(5);
            //// Map from Post model to PostSummary view model

            return PartialView("_ListPosts", mostViewedPosts);
        }

        [ChildActionOnly]
        public PartialViewResult LatestPosts()
        {
            ViewBag.PartialName = "Latest posts!";
            var latestPosts = postRepository.GetLatestPost(5);
            return PartialView("_ListPosts", latestPosts);
        }

        public ActionResult Detail(int year, int month, string urlSluq)
        {
            var post = postRepository.FindPost(year, month, urlSluq);
            if (post == null)
                return HttpNotFound();

            //var listCategory = db.Categories.ToList();

            return View(post);
        }


        public JsonResult addConment( Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Name = User.Identity.Name;
                comment.Email = User.Identity.GetUserName();
                comment.CommentTime = DateTime.Now;
                _CommentRepository.AddComment(comment);
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}
