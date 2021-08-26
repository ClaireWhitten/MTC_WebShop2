using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MTC_WebServerCore.Hubs;
using MTCmodel;
using MTCrepository.Repository;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        //========================================================================================================================
        // This method gets called by the runtime. Use this method to add services to the container.
        //========================================================================================================================

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            //service voor identity toevoegen
            //===============================
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                //options.Password.RequiredLength = 10;
                //options.Password.RequiredUniqueChars = 3;
            }
            )
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();//wachtwoord resetten, emailconfirmation

            //====================== Repositorys ============================
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("TestDB"), b => b.MigrationsAssembly("MTC_WebServerCore"))
            );

            services.AddScoped<IApplicationRepository, ApplicationRepository>();


            services.AddSignalR();


            //.RequireClaim("Create Role")
            //eventueel nog een cleam toevoegen aan de policy, het komt er wel
            //op neer dat de gebruiker dan pas voldoet aan de policy als deze alle 
            //cleams bevat, als je een 'of' relatie wil moet je een custom builder toevoegen
            //zie doc 99-105 => policy.RequireAssertion()
            services.AddAuthorization(options =>
            {
                foreach (var item in ClaimsStore.AllClaims)
                {
                    options.AddPolicy(item.Value,
                        policy => policy
                            .RequireClaim(item.Type)
                            .RequireRole("Administrator")
                        );
                }
            });
        }





        //========================================================================================================================
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //========================================================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //DIT WERKT NIET
            //app.UseSignalR(route =>
            //{
            //    route.MapHub<ChatHub>("CCC/dd");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHub<ChatHub>("/Chat/index");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
