using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GenericJQueryDevelopment.Startup))]
namespace GenericJQueryDevelopment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
