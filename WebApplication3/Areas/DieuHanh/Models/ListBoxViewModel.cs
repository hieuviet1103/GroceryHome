using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryHome.Areas.DieuHanh.Models
{
    public class ListBoxViewModel
    {
        public string SelectedItem { get; set; }
        public List<tbl_LoaiSanPham> selectItemList{get; set;}
    }
}