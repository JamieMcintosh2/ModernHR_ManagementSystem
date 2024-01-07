using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProfileService.Data;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ProfileService
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
            services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer
            (config["ConnectionStrings:ProfileConnection"]));



            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetConverter()); //Service configuered to convert date time to use only the date
                    })
                    .AddNewtonsoftJson(s => {
                        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });


            //services.AddScoped<IEmployeeRepo, MockRepo>();
            services.AddScoped<IEmployeeRepo, sqlEmployeeRepo>();

            //Adding services allowing them to be used in the app through dependency injection
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
