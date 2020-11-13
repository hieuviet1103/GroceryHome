using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using GroceryHome.Areas.DieuHanh.Models;
namespace GroceryHome.Areas.DieuHanh.Controllers
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
                try
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
                catch { }

            }            
            return View();
        }

        public ActionResult CapNhatSP(SanPham updateSP, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = Convert.ToInt32(id);
                var model = dB.tbl_SanPham.Find(Id);
                if (Request.HttpMethod == "POST")
                {
                    model.TenSP = updateSP.TenSP;
                    model.LoaiSP = updateSP.LoaiSP;
                    model.Mota = updateSP.Mota;
                    model.Gia = updateSP.Gia;
                    string path = ConfigurationManager.AppSettings["ProductPath"].ToString();

                    if (updateSP.ImageFile!=null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(updateSP.ImageFile.FileName);
                        string fileExtension = Path.GetExtension(updateSP.ImageFile.FileName);
                        string uploadPath = ConfigurationManager.AppSettings["ProductPath"].ToString();
                        updateSP.ImagePath = uploadPath + fileName + fileExtension;
                        updateSP.ImageFile.SaveAs(updateSP.ImagePath);
                        model.Hinh = updateSP.ImageFile.FileName;                        
                    }
                    dB.SaveChanges();
                    return RedirectToAction("Index");
                }
                
                updateSP.TenSP = model.TenSP;
                updateSP.LoaiSP = model.LoaiSP;
                updateSP.Mota = model.Mota;
                updateSP.Gia = Convert.ToDecimal(model.Gia);
                updateSP.FileName = model.Hinh;
                return View(updateSP);
            }
            return View("Index");
        }

        public ActionResult XoaSP(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = Convert.ToInt32(id);
                var model = dB.tbl_SanPham.Find(Id);
                dB.tbl_SanPham.Remove(model);
                dB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}