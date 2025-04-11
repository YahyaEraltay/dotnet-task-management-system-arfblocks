using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Serilog;
using Arfware.ArfBlocks.Core;
using Serilog.Core;

namespace Infrastructure.Services;

public class CustomLogger
{
    private readonly Logger _logger;
    private readonly CustomEnvironments _currentEnvironment;
    public CustomLogger(EnvironmentService environmentService, Logger logger)
    {
        _currentEnvironment = environmentService.Environment;
        _logger = logger;
    }

    private async Task Write(LogLevels logLevel, string message, params object[] args)
    {
        if (_currentEnvironment == CustomEnvironments.Test)
            return;

        // NOP:
        await Task.CompletedTask;

        // for (int i = 1; i < 20; i++)
        // {
        //     StackFrame frame1 = new StackFrame(i);
        //     var callerType1 = frame1.GetMethod().DeclaringType;

        //     if (callerType1 == null)
        //         callerType1 = typeof(Logger);

        //     _logger.Debug($"{i} : {callerType1.FullName}");
        // }

        StackFrame frame = new StackFrame(8);
        var callerType = frame.GetMethod().DeclaringType;

        if (callerType == null)
            callerType = typeof(CustomLogger);

        switch (logLevel)
        {
            case LogLevels.Debug:
                _logger.ForContext(callerType).Debug(message, args);
                break;

            case LogLevels.Information:
                _logger.ForContext(callerType).Information(message, args);
                break;

            case LogLevels.Warning:
                _logger.ForContext(callerType).Warning(message, args);
                break;

            case LogLevels.Error:
                _logger.ForContext(callerType).Error(message, args);
                break;

            default:
                throw new Exception($"Log Level Type: '{logLevel}' Not Handled");
        }
    }

    public async Task Debug(string message, params object[] args)
    {
        await Write(LogLevels.Debug, message, args);
    }

    public async Task Information(string message, params object[] args)
    {
        await Write(LogLevels.Information, message, args);
    }

    public async Task Warning(string message, params object[] args)
    {
        await Write(LogLevels.Warning, message, args);
    }

    public async Task Error(string message, params object[] args)
    {
        await Write(LogLevels.Error, message, args);
    }
}