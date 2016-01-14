using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QuoteQuiz.RestServices.Startup))]

namespace QuoteQuiz.RestServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}