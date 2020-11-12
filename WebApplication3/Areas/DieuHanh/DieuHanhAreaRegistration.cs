using System.Web.Mvc;

namespace GroceryHome.Areas.DieuHanh
{
    public class DieuHanhAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DieuHanh";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DieuHanh_default",
                "DieuHanh/{controller}/{action}/{id}",
                new { action = "Login", id = UrlParameter.Optional }
            );

            context.MapRoute(
               "Cap-Nhat-SanPham",
               "Cap-Nhat-SanPham",
               new { controler = "QuanLySanPham", action = "CapNhatSP", id = UrlParameter.Optional },
               new[] { "GroceryHome.Areas.DieuHanh.Controllers" }
               );

        }
    }
}