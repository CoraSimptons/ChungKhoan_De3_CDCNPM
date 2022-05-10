using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMChungKhoan.Startup))]
namespace DMChungKhoan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
