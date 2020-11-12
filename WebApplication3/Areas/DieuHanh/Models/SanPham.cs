using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Areas.DieuHanh.Models
{
    public class SanPham
    {
        public SanPham()
        {   
                     
        }

        public string TenSP { get; set; }
        public int LoaiSP { get; set; }
        public string Mota { get; set; }
        public decimal Gia { get; set; }
        public string Hinh { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}