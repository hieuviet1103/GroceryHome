using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Areas.DieuHanh.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: DieuHanh/QuanLyDonHang
        public ActionResult Index()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}