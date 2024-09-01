var builder = WebApplication.CreateBuilder(args);

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectConfigurations").Get<ProjectNameConfigurations>();
var environmentService = new EnvironmentService(configurations?.EnvironmentConfiguration);
var jsonFile = environmentService.Environment == CustomEnvironments.Development ? "serilog.Development.json" : "serilog.json";
IConfiguration Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(jsonFile, optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    // .AddCommandLine(args)
    .Build();



// ArfBlocks Dependencies
builder.Services.AddArfBlocks(options =>
{
    options.ApplicationProjectNamespace = "Application";
    options.ConfigurationSection = builder.Configuration.GetSection("ProjectConfigurations");
});

builder.Services.AddArfBlocksTests(options =>
{
    options.ApplicationProjectNamespace = "Application";
});

var app = builder.Build();