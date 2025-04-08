using Application.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectNameConfigurations").Get<ProjectNameConfigurations>();
var environmentService = new EnvironmentService(configurations?.EnvironmentConfiguration);
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
    options.ApplicationProjectNamespace = "Application";
    options.ConfigurationSection = builder.Configuration.GetSection("ProjectConfigurations");
    options.LogLevel = LogLevels.Warning;
});

builder.Services.AddArfBlocksTests(options =>
{
    options.ApplicationProjectNamespace = "Application";
    options.LogLevel = LogLevels.Warning;
});

var app = builder.Build();

await app.RunTests(app.Configuration, options =>
{
    options.TestConfigurationsType = typeof(TestConfigurations);

    // Run Only Selected Tests
    options.SelectedTestList = new List<Type>()
    {
    };


});