using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PersonRegister.Core.Application;
using PersonRegister.Infrastructure.Database;
using PersonRegister.Infrastructure.FileSystem;
using PersonRegister.Presentation.WebApi.ActionFilters;
using PersonRegister.Presentation.WebApi.Extensions;
using System.IO;

namespace PersonRegister.WebApi
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

            services.AddControllers().AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonRegister.WebApi", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "PersonRegister.Presentation.WebApi.xml");
                c.IncludeXmlComments(filePath);

            });
            services.AddScoped<ValidationFilterAttribute>();


            services.AddDatabaseLayer(Configuration);
            services.AddApplicationLayer(Configuration);
            services.AddFileSystemLayer(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonRegister.WebApi v1"));
            }

            app.UsePersonRegisterExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
