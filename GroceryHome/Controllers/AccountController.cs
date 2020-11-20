using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryHome.Models;

namespace GroceryHome.Controllers
{
    public class AccountController : Controller
    {
        private GroceryHomeEntities dB = new GroceryHomeEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerLogin(CustomerLoginViewModel model)
        {
            tbl_KhachHang UserLogin = new tbl_KhachHang();
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    if (dB.tbl_KhachHang.Any(d => d.UserName == model.UserName))
                    {
                        if (model.Password == dB.tbl_KhachHang.Where(d => d.UserName == model.UserName).FirstOrDefault().Password)
                        {
                            if (model.RememberMe)
                            {
                                Response.Cookies["CustomerLogin"].Value = model.UserName;
                            }
                            UserLogin = dB.tbl_KhachHang.Where(d => d.UserName == model.UserName).FirstOrDefault();
                            Session["CustomerLogin"] = model.UserName;
                            CustomerLoginStatus.IsLogin = true;
                            CustomerLoginStatus.CustomerUser = model.UserName;
                            CustomerLoginStatus.CustomerUserId = UserLogin.Id;
                            CustomerLoginStatus.CustomerName = UserLogin.FullName;                            
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            model.LoginError = "*Mật khẩu không chính xác";
                        }
                    }
                    else
                    {
                        model.LoginError = "*Tài khoản không chính xác";
                    }
                }
                catch
                {
                    model.LoginError = "*Lỗi không xác định";
                }
            }
            return View(model);
        }
        public ActionResult CustomerRegister(CustomerRegisterViewModel model )
        {
            if (Request.HttpMethod == "POST" )
            {
                if (!string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.ConfirmPassword) &&(model.Password == model.ConfirmPassword))
                {
                    if (!dB.tbl_KhachHang.Any(d => d.UserName == model.UserName))
                    {
                        tbl_KhachHang addKhachHang = new tbl_KhachHang();
                        addKhachHang.FullName = model.FullName;
                        addKhachHang.UserName = model.UserName;
                        addKhachHang.Password = model.Password;
                        addKhachHang.PhoneNumber = model.PhoneNumber;
                        addKhachHang.DiaChi = model.DiaChi;
                        dB.tbl_KhachHang.Add(addKhachHang);
                        dB.SaveChanges();

                        //redirect to Login
                        CustomerLoginViewModel login = new CustomerLoginViewModel();
                        login.UserName = model.UserName;
                        login.Password = model.Password;
                        return RedirectToAction("CustomerLogin", "Account", login);
                    }
                    else
                    {
                        model.Error = "Tài khoản đã tồn tại";
                    }
                }
                else
                {
                    return View();
                }
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["CustomerLogin"] = Response.Cookies["CustomerLogin"].Value = null;
            CustomerLoginStatus.IsLogin = false;
            CustomerLoginStatus.CustomerUser = null;
            return RedirectToAction("CustomerLogin");
        }
    }
}