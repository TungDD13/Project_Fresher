using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class HomeManageController : Controller
    {
        // GET: Admin/HomeManage
        public ActionResult Index()
        {
            return View();
        }
    }
}