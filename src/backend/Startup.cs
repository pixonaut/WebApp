using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace webapp
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
            // services.AddSwaggerGen(options =>
            // {
            //     options.DescribeAllEnumsAsStrings();
            //     options.DescribeStringEnumsInCamelCase();
            //     options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //     {
            //         Title = "HTTP API",
            //         Version = "v1",
            //         Description = "The Service HTTP API"
            //     });
            // });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            
            /*
             * Necessary for connectingSvelteKit to your ASP.NET API
             * Browsers won’t let you call 5000 directly from 5173 unless you configure CORS
             * This will add CORS to the ConfigureServices method. 
             */
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:5173") // SvelteKit dev server
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }
            
            app.UseAuthentication();

            // Enable CORS BEFORE MVC
            app.UseCors("AllowFrontend");
            app.UseMvcWithDefaultRoute();
            

            // // Swagger
            // app.UseSwagger()
            //     .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "HTTP API V1"); });
        }
    }
}