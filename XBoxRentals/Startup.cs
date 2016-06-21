using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XBoxRentals.Startup))]
namespace XBoxRentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
