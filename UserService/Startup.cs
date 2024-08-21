using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserService.Domain.Repositories;
using UserService.Domain.Services;
using UserService.Infrastructure.Repositories;

namespace UserService
{ 
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configura el contexto de la base de datos con SQL Server
        services.AddDbContext<UserContext>(options =>
            options.UseSqlServer("UserDb"));

        services.AddControllers(); // Agrega soporte para controladores
        services.AddSwaggerGen(); // Habilita Swagger para documentación de API

        // Configura la autenticación JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "cahr.com",
                    ValidAudience = "cahrcom",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ztzcahr"))
                };
            });

        // Registra el repositorio y el servicio de usuario
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<UsersService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Muestra errores en desarrollo
        }

        app.UseRouting(); // Habilita el enrutamiento
        app.UseAuthentication(); // Habilita la autenticación
        app.UseAuthorization(); // Habilita la autorización
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); // Mapea los controladores
        app.UseSwagger(); // Habilita Swagger
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService v1"); }); // Configura la UI de Swagger
    }
}
}
