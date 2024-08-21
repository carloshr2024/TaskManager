using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskService.Domain.Repositories;
using TaskService.Domain.Services;
using TaskService.Infrastructure.Repositories;

namespace TaskService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configura el contexto de la base de datos con SQL Server
            services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer("taskDB"));

            services.AddControllers(); // Agrega soporte para controladores
            services.AddSwaggerGen(); // Habilita Swagger para documentación de API

            // Registra el repositorio y el servicio de tareas
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<TasksService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Muestra errores en desarrollo
            }

            app.UseRouting(); // Habilita el enrutamiento
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); // Mapea los controladores
            app.UseSwagger(); // Habilita Swagger
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskService v1"); }); // Configura la UI de Swagger
        }
    }
}
