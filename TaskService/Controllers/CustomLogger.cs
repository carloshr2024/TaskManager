using Microsoft.Extensions.Logging;
using System;

public class CustomLogger : ILogger
{
    private readonly string _name;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="CustomLogger"/>.
    /// </summary>
    /// <param name="name">El nombre del logger.</param>
    public CustomLogger(string name)
    {
        _name = name;
    }

    /// <summary>
    /// Inicia un nuevo alcance de logging.
    /// </summary>
    /// <typeparam name="TState">El tipo del estado del logging.</typeparam>
    /// <param name="state">El estado del logging.</param>
    /// <returns>Un objeto que implementa <see cref="IDisposable"/> para el alcance.</returns>
    public IDisposable BeginScope<TState>(TState state) => null;

    /// <summary>
    /// Determina si el logging está habilitado para un nivel específico.
    /// </summary>
    /// <param name="logLevel">El nivel de logging.</param>
    /// <returns>Verdadero si el logging está habilitado; de lo contrario, falso.</returns>
    public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

    /// <summary>
    /// Registra un mensaje de logging.
    /// </summary>
    /// <typeparam name="TState">El tipo del estado del logging.</typeparam>
    /// <param name="logLevel">El nivel de logging.</param>
    /// <param name="eventId">El identificador del evento.</param>
    /// <param name="state">El estado del logging.</param>
    /// <param name="exception">La excepción asociada con el evento de logging.</param>
    /// <param name="formatter">Función que formatea el mensaje de logging.</param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (IsEnabled(logLevel))
        {
            Console.WriteLine($"{logLevel}: {_name} - {formatter(state, exception)}");
        }
    }
}
