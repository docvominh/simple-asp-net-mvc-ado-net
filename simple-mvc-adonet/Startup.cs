using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(simple_mvc_adonet.Startup))]
namespace simple_mvc_adonet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
