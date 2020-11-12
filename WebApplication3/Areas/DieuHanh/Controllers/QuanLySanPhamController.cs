using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using WebApplication3.Areas.DieuHanh.Models;
namespace WebApplication3.Areas.DieuHanh.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        private readonly GroceryHomeEntities dB = new GroceryHomeEntities();
        // GET: DieuHanh/QuanLySanPham
        public ActionResult Index()
        {
            var models = new List<tbl_SanPham>();
            if (!LoginSatus.IsloginAdmin)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {               
                if (dB.tbl_SanPham.Any(d=>d.Id != 0))
                {
                    models = dB.tbl_SanPham.Where(d => d.Id != 0).ToList();
                }
            }
            return View(models);
        }

        public ActionResult ThemMoiSP(SanPham model)
        {
            if (Request.HttpMethod == "POST")
            {
                if (model.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string fileExtension = Path.GetExtension(model.ImageFile.FileName);
                    string uploadPath = ConfigurationManager.AppSettings["ProductPath"].ToString();
                    model.ImagePath = uploadPath + fileName + fileExtension;
                    model.ImageFile.SaveAs(model.ImagePath);
                }
                tbl_SanPham addSanPham = new tbl_SanPham();
                addSanPham.TenSP = model.TenSP;
                addSanPham.LoaiSP = model.LoaiSP;
                addSanPham.Mota = model.Mota;
                addSanPham.Gia = model.Gia;
                addSanPham.Hinh = model.ImageFile.FileName;
                dB.tbl_SanPham.Add(addSanPham);
                dB.SaveChanges();

            }
            return View();
        }



        public ActionResult CapNhatSP()
        {
            return View();
        }
    }
}