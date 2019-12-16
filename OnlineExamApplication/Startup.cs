using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineExamApplication.Startup))]
namespace OnlineExamApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
