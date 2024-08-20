using Microsoft.Extensions.Logging;
using System;

/// <summary>
/// Implementación personalizada de un registrador de logs.
/// </summary>
public class CustomLogger : ILogger
{
    private readonly string _name;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="CustomLogger"/>.
    /// </summary>
    /// <param name="name">Nombre del logger, utilizado para identificar la fuente de los logs.</param>
    public CustomLogger(string name)
    {
        _name = name;
    }

    /// <summary>
    /// Inicia un nuevo ámbito de registro.
    /// </summary>
    /// <typeparam name="TState">El tipo del estado del log.</typeparam>
    /// <param name="state">El estado del log que se usará en el ámbito.</param>
    /// <returns>Un objeto que implementa <see cref="IDisposable"/> para el ámbito.</returns>
    public IDisposable BeginScope<TState>(TState state) => null;

    /// <summary>
    /// Determina si el nivel de log está habilitado.
    /// </summary>
    /// <param name="logLevel">El nivel de log a verificar.</param>
    /// <returns>True si el nivel de log está habilitado; de lo contrario, false.</returns>
    public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

    /// <summary>
    /// Registra un mensaje de log.
    /// </summary>
    /// <typeparam name="TState">El tipo del estado del log.</typeparam>
    /// <param name="logLevel">El nivel de log.</param>
    /// <param name="eventId">El identificador del evento.</param>
    /// <param name="state">El estado del log.</param>
    /// <param name="exception">La excepción asociada al log, si existe.</param>
    /// <param name="formatter">Función que formatea el estado y la excepción en un string.</param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (IsEnabled(logLevel))
        {
            Console.WriteLine($"{logLevel}: {_name} - {formatter(state, exception)}");
        }
    }
}
