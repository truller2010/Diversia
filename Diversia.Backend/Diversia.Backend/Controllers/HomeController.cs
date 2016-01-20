using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diversia.Backend.BlogSVC;
using Diversia.Core;
using Diversia.Models.BlogPost;

namespace Diversia.Backend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var lista=new List<BlogPostModel>();
            new BlogClient().Using(cache => {
               lista = cache.GetAll();
            });
            return View(lista);
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
    }
}