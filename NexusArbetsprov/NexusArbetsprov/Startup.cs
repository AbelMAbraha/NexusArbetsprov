using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexusArbetsprov.Startup))]
namespace NexusArbetsprov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
