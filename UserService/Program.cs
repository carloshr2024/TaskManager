using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserService
{
    /// <summary>
    /// Clase principal que inicia la aplicaci�n ASP.NET Core.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// M�todo de entrada principal para la aplicaci�n.
        /// </summary>
        /// <param name="args">Argumentos de l�nea de comandos.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Crea un generador de host para la aplicaci�n.
        /// </summary>
        /// <param name="args">Argumentos de l�nea de comandos.</param>
        /// <returns>Un generador de host configurado.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
