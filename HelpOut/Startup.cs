using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpOut.Startup))]
namespace HelpOut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //HelpOut.App_Start.Hangfire.ConfigureHangfire(app);
            //App_Start.Hangfire.InitializeJobs();

        }
    }
}
