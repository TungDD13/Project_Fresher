using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private TagRepository tagRepository ;

        public TagController()
        {
            tagRepository = new TagRepository();
        }

        [ChildActionOnly]
        public ActionResult PopurlarTags()
        {
            var popularTags = tagRepository.GetAllTags();
            return PartialView("_PopularTags", popularTags);
        }
    }
}