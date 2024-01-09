using System.Text.Json.Serialization;
using System.Text.Json;
using RecruitmentService.Data;
using RecruitmentService.Configurations;

namespace RecruitmentService
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

            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Startup>();
            var config = builder.Build();
            //Adding OpenAI so that it can be injected throughout the application
            services.Configure<OpenAIConfig>(config.GetSection("OpenAI"));
            services.AddSingleton(config.GetSection("OpenAI").Get<OpenAIConfig>());

            services.AddControllers();


            services.AddScoped<IRecruitmentRepo, BasicRecruitmentRepo>();
            //services.AddScoped<IEmployeeRepo, sqlEmployeeRepo>();

            //Adding services allowing them to be used in the app through dependency injection
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
