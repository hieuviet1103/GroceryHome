﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using GroceryHome.Areas.DieuHanh.Models;
using Microsoft.AspNet.Identity;

namespace GroceryHome.Areas.DieuHanh.Controllers
{
    public class LoginController : Controller
    {

        private readonly GroceryHomeEntities dB = new GroceryHomeEntities();

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


        public async Task<ActionResult> Index(LoginViewModel model)
        {
            if (!string.IsNullOrEmpty(Session["CurrentUser"].ToString())|| !string.IsNullOrEmpty(Request.Cookies["CurrentUser"].Value))
            {
                if (!string.IsNullOrEmpty(Request.Cookies["CurrentUser"].Value))
                {
                    Session["CurrentUser"] = Request.Cookies["CurrentUser"].Value;                    
                }
                LoginSatus.UserLogin = model.UserName = Session["CurrentUser"].ToString();
                LoginSatus.IsloginAdmin = true;                
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
                            Response.Cookies["CurrentUser"].Value = model.UserName;
                        }
                        Session["CurrentUser"] = model.UserName;
                        LoginSatus.IsloginAdmin = true;
                        LoginSatus.UserLogin = model.UserName;
                        //return View("Index", model);
                        return RedirectToAction("Index", "AdminHome");
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
            Response.Cookies["CurrentUser"].Value = null;
            Session["CurrentUser"] = null;
            LoginSatus.IsloginAdmin = false;
            return View("Login");
        }
    }
}