using CrashCouresServer;
using CrashCourseServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrashCourseServer
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
            // Added: Service Data Seeder
            services.AddTransient<DataSeeder>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            /* Configure CORS so the API allows requests from JavaScript.  
               For demo purposes, all origins/headers/methods are allowed.  */
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            /* Alternative: for connection string from config.json (not a sercure configuraion)
               services.AddDbContext<ProductImageDbContext>(options =>
               options.UseMySql(_config.GetConnectionString("dbconnect")));
               services.AddDbContext<AudioDbContext>(options =>
               options.UseMySql(_dbconnect)); */

            // Added: Services (such as BloggingContext) are registered with dependency injection during application startup.  
            var connection = @"Server=(localdb)\mssqllocaldb;Database=CrashCourseDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<EntryDbContext>
                (options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeder.InitializeData(app.ApplicationServices);
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
