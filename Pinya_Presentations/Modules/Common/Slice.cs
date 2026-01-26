using System.Diagnostics;

namespace Pinya_Presentations.Modules.Common;

public abstract class Slice<TInput, TOutput> 
{
    private Stopwatch _stopwatch;
    protected readonly ILogger<Slice<TInput, TOutput>> _logger;
    public Slice(ILogger<Slice<TInput, TOutput>> logger)
    {
        _stopwatch = new Stopwatch();
        _logger = logger;
    }

    public (string? Error, TOutput? Result) Handle(TInput input)
    {
        LogStart();
        var validationError = Validate(input);
        if (validationError is not null)
            return (validationError, default);
        var result = HandleInternal(input);
        LogEnd();
        return result;
    }

    private void LogStart()
    {
        _logger.Log(LogLevel.Information, $"{GetType().Name} start {DateTime.Now:O}");
        _stopwatch.Start();
    }

    private void LogEnd()
    {
        _stopwatch.Stop();
        _logger.Log(LogLevel.Information, $"{GetType().Name} end {DateTime.Now:O}\nTotal time: {_stopwatch.Elapsed}");
    }

    protected abstract string? Validate(TInput input);

    protected abstract (string? Error, TOutput? Result) HandleInternal(TInput input);
}
