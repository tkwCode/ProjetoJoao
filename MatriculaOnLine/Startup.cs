using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatriculaOnLine.Startup))]
namespace MatriculaOnLine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
