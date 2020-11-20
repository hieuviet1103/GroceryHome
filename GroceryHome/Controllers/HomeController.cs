using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryHome.Models;

namespace GroceryHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroceryHomeEntities dB = new GroceryHomeEntities();
        public ActionResult Index()
        {
            if (CustomerLoginStatus.IsLogin)
            {
                var models = dB.tbl_SanPham.Where(d => d.Id != 0).ToList();
                return View(models);
            }
            else
            {
                return RedirectToAction("CustomerLogin", "Account");
            }
        }

        public ActionResult GioHang()
        {
            List<tbl_GioHang_SanPham> ListSP = new List<tbl_GioHang_SanPham>();
            try
            {
                var IdKhachHang = dB.tbl_KhachHang.Where(d => d.UserName == CustomerLoginStatus.CustomerUser).FirstOrDefault().Id;
                var IdGioHang = dB.tbl_GioHang.Where(d => d.IdKhachHang == IdKhachHang && d.IsComplete == false).FirstOrDefault().Id;
                ListSP = dB.tbl_GioHang_SanPham.Where(d => d.IdGioHang == IdGioHang && d.IsDelete == 0 ).ToList();
            }
            catch { }
            return View(ListSP);
        }

        public ActionResult DonHang()
        {
            List<tbl_DatHang> ListDatHang = new List<tbl_DatHang>();
            try
            {
                var IdKhachHang = CustomerLoginStatus.CustomerUserId;
                ListDatHang = dB.tbl_DatHang.Where(d => d.IdKhachHang == IdKhachHang && d.IsDelete == false).ToList();
            }
            catch 
            {

               
            }
            return View(ListDatHang);
        }

        public ActionResult DetailsDonHang( string id)
        {
            Guid Id = new Guid(id);
            var IdGioHang = dB.tbl_DatHang.Find(Id).IdGioHang;
            var listSanPham = dB.tbl_GioHang_SanPham.Where(d => d.IdGioHang == IdGioHang && d.IsDelete == 0).ToList();
            return View(listSanPham);
        }
        public ActionResult AddSpToGioHang(string id, string count)
        {
            if (CustomerLoginStatus.IsLogin)
            {
                try
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        int Id = Convert.ToInt32(id);
                        int Count;
                        Int32.TryParse(count, out Count);
                        if (CustomerLoginStatus.IsLogin)
                        {
                            int idKhachHang = Convert.ToInt32(dB.tbl_KhachHang.Where(d => d.UserName == CustomerLoginStatus.CustomerUser).FirstOrDefault().Id);

                            if (!dB.tbl_GioHang.Any(d => d.IdKhachHang == idKhachHang && d.IsComplete == false))
                            {
                                //Add Giỏ hàng
                                tbl_GioHang newGioHang = new tbl_GioHang();
                                newGioHang.IdKhachHang = idKhachHang;
                                newGioHang.NgayTao = DateTime.Now;
                                newGioHang.IsDelete = false;
                                newGioHang.IsComplete = false;
                                dB.tbl_GioHang.Add(newGioHang);
                                dB.SaveChanges();

                                //Add sản phẩm vào giỏ
                                tbl_GioHang_SanPham newSanPham = new tbl_GioHang_SanPham();
                                var IdGioHang = dB.tbl_GioHang.Where(d => d.IdKhachHang == idKhachHang).FirstOrDefault().Id;
                                var SanPham = dB.tbl_SanPham.Find(Id);
                                newSanPham.IdGioHang = IdGioHang;
                                newSanPham.IdSanPham = Convert.ToInt32(Id);
                                newSanPham.TenSP = SanPham.TenSP;
                                newSanPham.SoLuong = Count != 0 ? Count : 1;
                                newSanPham.DonGia = SanPham.Gia;
                                newSanPham.ThanhTien = newSanPham.DonGia * newSanPham.SoLuong;
                                newSanPham.NgayThem = DateTime.Now;
                                newSanPham.IsDelete = 0;
                                dB.tbl_GioHang_SanPham.Add(newSanPham);
                                dB.SaveChanges();
                            }

                            else
                            {
                                //Add sản phẩm vào giỏ
                                tbl_GioHang_SanPham newSanPham = new tbl_GioHang_SanPham();
                                var IdGioHang = dB.tbl_GioHang.Where(d => d.IdKhachHang == idKhachHang && d.IsComplete == false).FirstOrDefault().Id;
                                var SanPham = dB.tbl_SanPham.Find(Id);
                                if (dB.tbl_GioHang_SanPham.Any(d => d.IdGioHang == IdGioHang && d.IdSanPham == Id && d.IsDelete == 0))
                                {
                                    newSanPham = dB.tbl_GioHang_SanPham.Where(d => d.IdGioHang == IdGioHang && d.IdSanPham == Id && d.IsDelete == 0).FirstOrDefault();
                                    newSanPham.SoLuong += Count != 0 ? Count : 1;
                                    newSanPham.ThanhTien = newSanPham.DonGia * newSanPham.SoLuong;
                                    dB.SaveChanges();
                                }
                                else
                                {
                                    newSanPham.IdGioHang = IdGioHang;
                                    newSanPham.IdSanPham = Convert.ToInt32(Id);
                                    newSanPham.TenSP = SanPham.TenSP;
                                    newSanPham.SoLuong = Count != 0 ? Count : 1;
                                    newSanPham.DonGia = SanPham.Gia;
                                    newSanPham.ThanhTien = newSanPham.DonGia * newSanPham.SoLuong;
                                    newSanPham.NgayThem = DateTime.Now;
                                    newSanPham.IsDelete = 0;
                                    dB.tbl_GioHang_SanPham.Add(newSanPham);
                                    dB.SaveChanges();
                                }
                            }
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    Session["IsAddSanPham"] = "Không thể thêm sản phẩm vào giỏ";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("CustomerLogin","Account");
            }
        }

        public ActionResult XoaSPGioHang(string id)
        {
            int Id = Convert.ToInt32(id);
            var delSPGioHang = dB.tbl_GioHang_SanPham.Find(Id);
            delSPGioHang.IsDelete = 1;
            dB.SaveChanges();
            return RedirectToAction("GioHang");
        }
        public void DatHang(string id)
        {
            int Id = Convert.ToInt32(id);
            var CurrentUser = dB.tbl_KhachHang.Find(CustomerLoginStatus.CustomerUserId);
            var GioHang = dB.tbl_GioHang.Find(Id);
            var SanPham = dB.tbl_GioHang_SanPham.Where(d => d.IdGioHang == Id && d.IsDelete == 0).ToList();
            decimal? TongTien = 0;
            foreach (var item in SanPham)
            {
                TongTien += item.ThanhTien;
                var DsSanPham = dB.tbl_SanPham.Find(item.IdSanPham);
                DsSanPham.SoLuongConLai -= item.SoLuong;
            }
            tbl_DatHang datHang = new tbl_DatHang();
            datHang.Id = Guid.NewGuid();
            datHang.IdGioHang = Id;
            datHang.IdKhachHang = CustomerLoginStatus.CustomerUserId;
            datHang.TenKhachHang = CustomerLoginStatus.CustomerName;
            datHang.DiaChi = CurrentUser.DiaChi;
            datHang.Phone = CurrentUser.PhoneNumber;
            datHang.NgayDatHang = DateTime.Now;
            datHang.TongHoaDon = TongTien;
            datHang.Status = 0;
            datHang.IsDelete = false;
            dB.tbl_DatHang.Add(datHang);
            GioHang.IsComplete = true;
            dB.SaveChanges();
        }
    }
}