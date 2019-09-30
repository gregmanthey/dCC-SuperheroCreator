using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperheroCreator.Startup))]
namespace SuperheroCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
