using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Areas.DieuHanh.Models
{
    public class LoginSatus
    {
        public static bool IsloginAdmin { get; set; }
        public string UserName = string.Empty;
        public string PassWord = string.Empty;

    }
}