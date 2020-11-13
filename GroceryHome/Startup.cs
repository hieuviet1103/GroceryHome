using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroceryHome.Startup))]
namespace GroceryHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
