using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using EmploymentService.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmploymentService
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });
            //Adding db conext based on our connection string name
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Startup>();
            var config = builder.Build();

            // Checking if we're running in Azure
            var isRunningInAzure = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME"));

            // Checking if we're running locally or in Docker container
            var isRunningInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");

            if (isRunningInAzure)
            {
                // For Azure
                var connectionString = Environment.GetEnvironmentVariable("Azure_EmploymentConnection");
                services.AddDbContext<dbContext>(opt => opt.UseSqlServer(connectionString));
            }
            else if (isRunningInDocker == "true")
            {
                // For Docker
                var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__EmploymentConnection");
                services.AddDbContext<dbContext>(opt => opt.UseSqlServer(connectionString));
            }
            else
            {
                // For local
                var connectionString = Configuration.GetConnectionString("EmploymentConnection");
                services.AddDbContext<dbContext>(opt => opt.UseSqlServer(connectionString));
            }

            //For Docker?
            //var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__EmploymentConnection");
            //services.AddDbContext<dbContext>(opt => opt.UseSqlServer(connectionString));

            //For local?
            /*services.AddDbContext<dbContext>(opt => opt.UseSqlServer
             (config["ConnectionStrings:EmploymentConnection"]));*/

            services.AddControllers()
                                    .AddNewtonsoftJson(s => {
                                        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                                    });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IEmploymentRepo, SqlEmploymentRepo>();


            //services.AddScoped<IEmploymentRepo, sqlEmploymentRepo>();

            //For Hardcoded connection string
            //Adding db conext based on our connection string name
            /*services.AddDbContext<dbContext>(opt => opt.UseSqlServer
             (Configuration.GetConnectionString("EmploymentConnection")));*/



            //Adding services allowing them to be used in the app through dependency injection
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Removed for Docker
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
