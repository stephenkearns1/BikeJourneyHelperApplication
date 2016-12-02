using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeJourneyHelperApplication.Startup))]
namespace BikeJourneyHelperApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
