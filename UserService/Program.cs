using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserService
{
    /// <summary>
    /// Clase principal que inicia la aplicación ASP.NET Core.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método de entrada principal para la aplicación.
        /// </summary>
        /// <param name="args">Argumentos de línea de comandos.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Crea un generador de host para la aplicación.
        /// </summary>
        /// <param name="args">Argumentos de línea de comandos.</param>
        /// <returns>Un generador de host configurado.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
