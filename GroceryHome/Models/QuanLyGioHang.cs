using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryHome.Models
{
    public class QuanLyGioHang
    {

    }

    public class SanPhamDaDat
    {
        public int Id { get; set; }
        public int IdSanPham { get; set; }
        public int IdGioHang { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<float> DonGia { get; set; }
        public Nullable<float> ThanhTien { get; set; }
        public Nullable<System.DateTime> NgayThem { get; set; }
        public Nullable<int> IsDelete { get; set; }

    }
}