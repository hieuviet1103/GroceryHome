using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using WebApplication3.Areas.DieuHanh.Models;
using WebApplication3.Models;

namespace WebApplication3.Areas.DieuHanh.Controllers
{
    public class LoginController : Controller
    {

        private readonly GroceryHomeEntities dB = new GroceryHomeEntities();
        Models.LoginSatus loginStatus = new Models.LoginSatus();

        // GET: DieuHanh/Login

        //public ActionResult Index()
        //{
        //    if (!string.IsNullOrEmpty(Request["userName"]) && !string.IsNullOrEmpty(Request["passWord"]))
        //    {
        //        LoginViewModel model = new LoginViewModel();
        //        model.UserName = Request["userName"];
        //        model.Password = Request["passWord"];
        //        return View("Login", model);
        //    }
        //    return View();
        //}
        public ActionResult Index(LoginViewModel model)
        {
            if (!string.IsNullOrEmpty(Request["userName"]) && !string.IsNullOrEmpty(Request["passWord"]))
            {
                model.UserName = Request["userName"];
                model.Password = Request["passWord"];
                return View(model);
            }
            return View("Login");
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        { 
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (dB.tbl_User.Any(d => d.User_Name == model.UserName))
                {
                    if (dB.tbl_User.Any(d => d.Password == model.Password))
                    {
                        if (model.RememberMe == true)
                        {
                            Response.Cookies["userName"].Value = model.UserName;
                            Response.Cookies["passWord"].Value = model.Password;
                        }
                        Models.LoginSatus.IsloginAdmin = true;        
                        //return View("Index", model);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        model.LoginError = "*Mật khẩu không chính xác!";
                    }
                }
                else
                {
                    model.LoginError = "*Tên tài khoản không chính xác!";
                }
            }
            catch
            {
                model.LoginError = "Lỗi không xác định!";
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Response.Cookies["userName"].Value = null;
            Response.Cookies["passWord"].Value = null;
            Models.LoginSatus.IsloginAdmin = false;
            return View("Login");
        }
    }
}