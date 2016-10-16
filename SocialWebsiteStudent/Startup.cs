using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialWebsiteStudent.Startup))]
namespace SocialWebsiteStudent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
