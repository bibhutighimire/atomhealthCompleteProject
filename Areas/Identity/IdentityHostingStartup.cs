using AtomHealth.Areas.Identity.Data;
using AtomHealth.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AtomHealth.Areas.Identity.IdentityHostingStartup))]
namespace AtomHealth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AtomHealthDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AtomHealthDBContextConnection")));

                
                services.AddIdentity<AtomHealthUser,IdentityRole>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = true;
                })
                 .AddDefaultTokenProviders()
                .AddDefaultUI()
                    .AddEntityFrameworkStores<AtomHealthDBContext>();


            });
        }
    }
}