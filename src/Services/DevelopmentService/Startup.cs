using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;
using DevelopmentService.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace DevelopmentService
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
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetConverter()); //Service configuered to convert date time to use only the date
                    });

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
                var connectionString = Environment.GetEnvironmentVariable("Azure_DevelopmentConnection");
                services.AddDbContext<dbContext>(opt => opt.UseNpgsql(connectionString));
            }
            else if (isRunningInDocker == "true")
            {
                // For Docker
                var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DevelopmentConnection");
                services.AddDbContext<dbContext>(opt => opt.UseNpgsql(connectionString));
            }
            else
            {
                // For local
                var connectionString = Configuration.GetConnectionString("DevelopmentConnection");
                Console.WriteLine("Local");
                services.AddDbContext<dbContext>(opt => opt.UseNpgsql(connectionString));
            }

            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

           // services.AddScoped<IDevelopmentRepo, TestRepo>();
            services.AddScoped<IDevelopmentRepo, SqlDevelopmentRepo>();



        }
        //Class is converting datetime to be only the date
        public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTimeOffset.Parse(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Date.ToString("yyyy-MM-dd"));
            }
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

