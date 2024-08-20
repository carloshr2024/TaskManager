using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace TaskService
{
    public class Startup
    {
        /// <summary>
        /// Configura los servicios de la aplicación.
        /// </summary>
        /// <param name="services">La colección de servicios a configurar.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configura el contexto de la base de datos con SQL Server
            services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer("DefaultConnection"));

            // Agrega servicios para controladores
            services.AddControllers();

            // Configura Swagger para la documentación de la API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskService", Version = "v1" });
            });

            // Agrega un logger personalizado
            services.AddSingleton<ILogger, CustomLogger>();
        }

        /// <summary>
        /// Configura el middleware de la aplicación.
        /// </summary>
        /// <param name="app">El pipeline de la aplicación.</param>
        /// <param name="env">El entorno de la aplicación.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuración para el entorno de desarrollo
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskService v1"));
            }

            app.UseRouting();

            // Configura los endpoints de la aplicación
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapMetrics(); // Para Prometheus
            });
        }
    }
}
