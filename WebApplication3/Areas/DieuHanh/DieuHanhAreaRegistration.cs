using System.Web.Mvc;

namespace WebApplication3.Areas.DieuHanh
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
        }
    }
}