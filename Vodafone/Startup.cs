using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vodafone.Startup))]
namespace Vodafone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
