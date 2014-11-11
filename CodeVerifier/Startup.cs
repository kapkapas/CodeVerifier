using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeVerifier.Startup))]
namespace CodeVerifier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
