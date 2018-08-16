using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DLMallas.Startup))]
namespace DLMallas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
