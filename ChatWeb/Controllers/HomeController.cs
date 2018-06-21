using ChatWeb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWeb.Controllers
{
    [MyAuthorizeAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Id"] != null)
                ViewBag.UserId = Session["Id"];
            return View();
        }                
    }
}