using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigSchooll_PhanTrongNhan.Startup))]
namespace BigSchooll_PhanTrongNhan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
