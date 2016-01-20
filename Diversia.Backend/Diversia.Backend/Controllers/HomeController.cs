using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diversia.Backend.BlogSVC;
using Diversia.Core;
using Diversia.Core.Filter;
using Diversia.Core.Pager;
using Diversia.Models.BlogPost;

namespace Diversia.Backend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Page<BlogPostModel> page = null;
            FindRequestImpl<SearchFilter> filter = new FindRequestImpl<SearchFilter>();
            new BlogClient().Using(cache => {
               page = cache.Paginated(filter);
            });
            return View(page);
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