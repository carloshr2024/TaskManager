using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using UserService;

public class Program
{
    public static void Main(string[] args)
    {
        // Inicia la aplicación
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                // Usa la clase Startup para la configuración
                webBuilder.UseStartup<Startup>();
            });
}
