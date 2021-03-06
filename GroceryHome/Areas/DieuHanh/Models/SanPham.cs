﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryHome.Areas.DieuHanh.Models
{
    public class SanPham
    {
        public SanPham()
        {   
                     
        }
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Loại sản phẩm")]
        public int LoaiSP { get; set; }
        public string LoaiSPMoi { get; set; }

        [DisplayName("Mô tả")]
        public string Mota { get; set; }
        [DisplayName("Giá")]
        public decimal Gia { get; set; }
        [DisplayName("Ảnh minh họa")]
        public string ImagePath { get; set; }
        public string FileName { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}