
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using DLMallas.App_Start;

namespace DLMallas
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // NOTA: cookieDomain se configura en app.config
            var options = new CookieAuthenticationOptions
            {
                TicketDataFormat = new FormsAuthTicketDataFormat(),
                CookieName = ".ASPXAUTH",
                CookiePath = "/",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()

            };

            var cookieDomain = ConfigurationManager.AppSettings["dl:cookieDomain"];
            if (!string.IsNullOrWhiteSpace(cookieDomain))
            {
                options.CookieDomain = cookieDomain;
            }

            app.UseCookieAuthentication(options);
        }
    }
}