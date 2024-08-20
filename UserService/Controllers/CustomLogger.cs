using Microsoft.Extensions.Logging;
using System;

public class CustomLogger : ILogger
{
    private readonly string _name;

    public CustomLogger(string name)
    {
        _name = name;
    }

    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (IsEnabled(logLevel))
        {
            Console.WriteLine($"{logLevel}: {_name} - {formatter(state, exception)}");
        }
    }
}
