
using Arfware.ArfBlocks.Test.Middlewares;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectConfigurations").Get<ProjectConfigurations>();
var environmentService = new EnvironmentService(configurations.EnvironmentConfiguration);
var jsonFile = environmentService.Environment == CustomEnvironments.Development ? "serilog.Development.json" : "serilog.json";
IConfiguration Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(jsonFile, optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    // .AddCommandLine(args)
    .Build();

var logger = new LoggerConfiguration()
      .ReadFrom.Configuration(Configuration)
      .CreateLogger();

builder.Services.AddSingleton(logger);

// ArfBlocks Dependencies
builder.Services.AddArfBlocks(options =>
{
    options.ApplicationProjectNamespace = "Station.Application";
    options.ConfigurationSection = builder.Configuration.GetSection("ProjectConfigurations");
    options.LogLevel = LogLevels.Warning;
});

builder.Services.AddArfBlocksTests(options =>
{
    options.ApplicationProjectNamespace = "Station.Application";
    options.LogLevel = LogLevels.Warning;
});

var app = builder.Build();

await app.RunTests(app.Configuration, options =>
{
    options.TestConfigurationsType = typeof(TestConfigurations);

    // Run Only Selected Tests
    options.SelectedTestList = new List<Type>()
    {
        // typeof(Application.RequestHandlers.FillingPoints.Commands.Create.Tests.HappyPath),
        // typeof(Application.RequestHandlers.FillingPoints.Commands.Create.Tests.Permission),
    };

    // Skip Running Ignored Tests 
    // options.IgnoredTestList = new List<Type>()
    // {
    // };
});

public class TankDevice : ITankDeviceConnector
{
    public Task<bool> TankCompleteFilling(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TankMeasurementRequested(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TankStartFilling(string payload, string fuelLitre)
    {
        throw new NotImplementedException();
    }
}

public class UpsDevice : IUpsDeviceConnector
{
    public Task<bool> UpsMeasurementRequested(string payload)
    {
        throw new NotImplementedException();
    }
}

public class PumpDevice : IPumpDeviceConnector
{
    public Task<bool> PumpAuthorizationRequested(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PumpCompleteDataReady(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PumpMeasurementRequested(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PumpSaleCreated(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PumpUpdateDataReady(string payload)
    {
        throw new NotImplementedException();
    }
}

public class WebDevice : IWebConnector
{
    public Task<bool> PumpSaleCompleted(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PumpSaleStarted(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PumpSaleUpdated(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TankMeasureCreated(string payload)
    {
        throw new NotImplementedException();
    }
}
