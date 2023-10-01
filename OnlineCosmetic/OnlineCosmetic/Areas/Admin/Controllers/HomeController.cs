using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCosmetic.Areas.Admin.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("/admin")]
        [Route("/admin/home")]
        [Route("/admin/home/index")]
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}