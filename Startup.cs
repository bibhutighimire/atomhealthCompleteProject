using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using AtomHealth.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using AtomHealth.Data;
using AtomHealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace AtomHealth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);//You can set Time   
            });

            services.AddDbContext<AtomHealthDBContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("AtomHealthDBContextConnection")));

            services.AddScoped<DbContext, AtomHealthDBContext>();

            services.AddIdentity<AtomHealthUser, IdentityRole>(options => {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedAccount = true;
            })
                  .AddDefaultTokenProviders()
                 .AddDefaultUI()
                     .AddEntityFrameworkStores<AtomHealthDBContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContextPool<ConnectionDB>(options => options.UseSqlServer(Configuration.GetConnectionString("AtomHealthDBContextConnection")));

            services.AddTransient<IEmailSender, EmailSender>(i =>
               new EmailSender(
                   Configuration["EmailSender:Host"],
                   Configuration.GetValue<int>("EmailSender:Port"),
                   Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   Configuration["EmailSender:UserName"],
                   Configuration["EmailSender:Password"]
               )
           );



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

          

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
              
                endpoints.MapRazorPages();

            });
        }
    }
}
