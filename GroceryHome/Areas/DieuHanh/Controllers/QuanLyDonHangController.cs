using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryHome.Areas.DieuHanh.Controllers
{
    public class QuanLyDonHangController : Controller
    {

        private readonly GroceryHomeEntities dB = new GroceryHomeEntities();
        // GET: DieuHanh/QuanLyDonHang
        public ActionResult Index()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<tbl_DatHang> ListDatHang = new List<tbl_DatHang>();
            try
            {
                ListDatHang = dB.tbl_DatHang.Where(d => d.IsDelete == false).ToList();
            }
            catch
            {


            }
            return View(ListDatHang);
        }

        public void ConfirmDonHang(string id, string status)
        {
            Guid Id = new Guid(id);
            var donHang = dB.tbl_DatHang.Find(Id);
            donHang.Status = 1;
            dB.SaveChanges();
        }

        public void RejectDonHang(string id, string status)
        {
            Guid Id = new Guid(id);
            var donHang = dB.tbl_DatHang.Find(Id);
            donHang.Status = 2;
            dB.SaveChanges();
        }

        public ActionResult DonChoDuyet()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<tbl_DatHang> ListDatHang = new List<tbl_DatHang>();
            try
            {
                ListDatHang = dB.tbl_DatHang.Where(d => d.IsDelete == false && d.Status == 0).ToList();
            }
            catch
            {


            }
            return View(ListDatHang);
        }

        public ActionResult DonDaHuy()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<tbl_DatHang> ListDatHang = new List<tbl_DatHang>();
            try
            {
                ListDatHang = dB.tbl_DatHang.Where(d => d.IsDelete == false && d.Status == 2).ToList();
            }
            catch
            {


            }
            return View(ListDatHang);

        }

        public ActionResult DaXacNhan()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<tbl_DatHang> ListDatHang = new List<tbl_DatHang>();
            try
            {
                ListDatHang = dB.tbl_DatHang.Where(d => d.IsDelete == false && d.Status ==1).ToList();
            }
            catch
            {


            }
            return View(ListDatHang);
        }
    }
}