using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace UserService
{
    /// <summary>
    /// Clase de configuración de la aplicación ASP.NET Core.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configura los servicios de la aplicación.
        /// </summary>
        /// <param name="services">Colección de servicios a configurar.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración del contexto de base de datos
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer("DefaultConnection"));

            services.AddControllers();

            // Configuración de autenticación JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "UserTask",
                        ValidAudience = "TaskAudience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ADBFSDG"))
                    };
                });

            // Configuración de Swagger para documentación de API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService", Version = "v1" });
            });

            // Registro de un logger personalizado
            services.AddSingleton<ILogger, CustomLogger>();
        }

        /// <summary>
        /// Configura la tubería de middleware de la aplicación.
        /// </summary>
        /// <param name="app">Aplicación a configurar.</param>
        /// <param name="env">Entorno de ejecución.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapMetrics(); // Para Prometheus
            });
        }
    }
}
