using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Hubs;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.OptionModels;
using SviyajskMonitorSystem.Services;
using System;
using System.IO;
using System.Threading.Tasks;
//using Microsoft.AspNet.SignalR;
namespace SviyajskMonitorSystem
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SmSystem"));// UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();

            var serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
            services.Add(new ServiceDescriptor(typeof(Newtonsoft.Json.JsonSerializer),
                         provider => serializer,
                         ServiceLifetime.Transient));
            services.AddIdentity<ApplicationUser, IdentityRole>(opts=> {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddOptions();
            services.Configure<SendEmailOptions>(Configuration);
            // Add application services.
            services.AddTransient<IEmailSender,EmailSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            string destination = Configuration.GetSection("Filepath").Value;
            services.AddScoped<FileUpload>(provider => new FileUpload(destination));
            services.AddSingleton<PlaceSamplesService>();
           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseSession();
           // app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //  app.UseApplicationInsightsExceptionTelemetry();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/x-msdownload"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                RequestPath="/node_modules",
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/x-msdownload"
            });

            app.UseAuthentication();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=FirstPage}/{id?}");
            });
            app.UseWebSockets();
            app.UseSignalR();
            AddFirstUser(app.ApplicationServices).Wait();
           
        }



        private async  Task AddFirstUser(IServiceProvider serviceProvider)
        {
            var s = serviceProvider.CreateScope();
            UserManager<ApplicationUser> manager = s.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager =s.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("Researcher"))
            {
                await roleManager.CreateAsync(new IdentityRole("Researcher"));
            }
            string name = Configuration.GetSection("Admin:Login").Value;
            string password= Configuration.GetSection("Admin:Password").Value;
            if (await manager.FindByNameAsync(name) == null)
            {
                ApplicationUser admin = new ApplicationUser();
                admin.UserName = name;
                admin.Email = name;
                var result= await manager.CreateAsync(admin,password);
                if (result.Succeeded) {
                    await manager.AddToRoleAsync(admin, "Admin");
                }
            }
             name = Configuration.GetSection("Researcher:Login").Value;
             password = Configuration.GetSection("Researcher:Password").Value;
            if (await manager.FindByNameAsync(name) == null)
            {
                ApplicationUser researcher = new ApplicationUser();
                researcher.UserName = name;
                researcher.Email = name;
                var result = await manager.CreateAsync(researcher, password);
                if (result.Succeeded)
                {
                    await manager.AddToRoleAsync(researcher, "Researcher");
                }
            }
            name = Configuration.GetSection("Laborant:Login").Value;
            password = Configuration.GetSection("Laborant:Password").Value;
            if (await manager.FindByNameAsync(name) == null)
            {
                ApplicationUser laborant = new ApplicationUser();
                laborant.UserName = name;
                laborant.Email = name;
                var result = await manager.CreateAsync(laborant, password);
                //if (result.Succeeded)
                //{
                //    await manager.AddToRoleAsync(laborant, "Researcher");
                //}
            }
        }

    }
}
