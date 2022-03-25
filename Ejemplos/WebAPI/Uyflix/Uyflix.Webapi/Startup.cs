using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uyflix.IBusiness;
using Uyflix.Business;
using Uyflix.IDataAccess;
using Uyflix.DataAccess;

namespace Uyflix.Webapi
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
            services.AddControllers();

            services.AddScoped<IMoviesService, MoviesService>();

            // La instancia vive por cada request y se reutiliza dentro de la misma peticion
            services.AddScoped<IMoviesManagment, MoviesManagment>();
            // Se crea una instancia por cada vez que se llama a la interfaz
            //services.AddTransient<IMoviesManagment, MoviesManagment>();
            // Se crea una instancia la primera vez y luego las reutiliza entre diferentes peticiones
            //services.AddSingleton<IMoviesManagment, MoviesManagment>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
