using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TaskService;

public class Program
{
    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos.</param>
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    /// Crea y configura un <see cref="IHostBuilder"/> para la aplicación.
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos.</param>
    /// <returns>Un <see cref="IHostBuilder"/> configurado.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
