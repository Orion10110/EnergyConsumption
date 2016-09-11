using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnergyConsumption.Startup))]
namespace EnergyConsumption
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
