using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using DataCommunication.Services;
using Microsoft.AspNet.Identity;
using DataCommunication.Interfaces;

[assembly: OwinStartup(typeof(SocialNetwork.App_Start.Startup))]

namespace SocialNetwork.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}
