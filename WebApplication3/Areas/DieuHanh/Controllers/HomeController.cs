using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Areas.DieuHanh.Models;

namespace WebApplication3.Areas.DieuHanh.Controllers
{
    public class HomeController : Controller
    {
        // GET: DieuHanh/Home
        public ActionResult Index()
        {
            //if (!string.IsNullOrEmpty(Request["userName"]) && !string.IsNullOrEmpty(Request["passWord"]))
            //{
            //    return View();
            //}
            if (LoginSatus.IsloginAdmin == true)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }
    }
}