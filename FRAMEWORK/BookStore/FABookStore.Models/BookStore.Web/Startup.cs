using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(BookStore.Web.Startup))]
namespace BookStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
