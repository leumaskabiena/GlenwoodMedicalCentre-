using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlenwoodMedicalCentre.Startup))]
namespace GlenwoodMedicalCentre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
