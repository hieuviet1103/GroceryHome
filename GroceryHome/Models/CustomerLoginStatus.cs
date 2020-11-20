using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryHome.Models
{
    public class CustomerLoginStatus
    {
        public static bool IsLogin = false;
        public static string CustomerUser { get; set; }
        public static int CustomerUserId { get; set; }
        public static string  CustomerName { get; set; }
    }
}