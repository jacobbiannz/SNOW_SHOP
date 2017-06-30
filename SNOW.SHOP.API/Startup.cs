using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SNOW.SHOP.API.Data;
using Swashbuckle.AspNetCore.Swagger;
using SNOW.SHOP.API.src.Data;
using SNOW.SHOP.API.src.Abstract;
using SNOW.SHOP.API.API.ViewModel.Mapping;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using SNOW.SHOP.API.API.Core;
namespace SNOW.SHOP.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            // Add framework services.

          //  var config = new MapperConfiguration(cfg =>
          //  {
          //      cfg.AddProfile(new AutoMapperProfileConfiguration());
          //  });

            // Automapper Configuration
            AutoMapperConfiguration.Configure();

            // Enable Cors
            services.AddCors();

            // var mapper = config.CreateMapper();

            //  services.AddSingleton(mapper);

            services.AddMvc()
            .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
            .AddXmlDataContractSerializerFormatters();

            services.AddEntityFrameworkSqlServer().AddDbContext<SnowShopAPIDbContext>();

            services.AddScoped<IEntityMapper, SNOWAPIEntityMapper>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddOptions();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Snow Shop API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SnowShopAPIDbContext context)
        {
            app.UseResponseCompression();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Add MVC to the request pipeline.
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseExceptionHandler(
             builder =>
             {
                 builder.Run(
                   async httpContext =>
                   {
                       httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                       httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                       var error = httpContext.Features.Get<IExceptionHandlerFeature>();
                       if (error != null)
                       {
                           httpContext.Response.AddApplicationError(error.Error.Message);
                           await httpContext.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                       }
                   });
             });

            app.UseJwtBearerAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);

            app.UseSwagger();
            

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Snow Shop API V1");
            });

        }
    }
}
