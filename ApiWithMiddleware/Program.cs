
using Serilog;

var acceptedEnvironments = new List<string>() { "production", "staging", "development" };
var isArgsOne = args.Length == 1;

if (args.Length != 1 || !acceptedEnvironments.Contains(args[0]))
{
	Console.WriteLine("Error: You must specify environment; such as production or staging or development\nDefault environment development...");
	args = new string[] { "development" };
	// return;
}

var configuration = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  // .AddJsonFile("appsettings.staging.json", false, false)
  .AddJsonFile($"appsettings.{args[0]}.json", true, false)
  .AddEnvironmentVariables()
  .Build();

var builder = WebApplication.CreateBuilder(args);

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectNameConfigurations").Get<ProjectConfigurations>();
var environmentService = new EnvironmentService(configurations.EnvironmentConfiguration);
var dbContext = new ApplicationDbContext(new CustomDbContextOptions(configurations.RelationalDbConfiguration, environmentService));
builder.Services.AddSingleton<ApplicationDbContext>(dbContext);

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

logger.Information("Application running for {@payload}", args[0]);

builder.Services.AddSingleton(dbContext);
builder.Services.AddSingleton(logger);

// Migrate Database
if (isArgsOne)
{
	logger.Information($"Database Migrate Started");
	await dbContext.Database.MigrateAsync();
	logger.Information($"Database Migrated");
}

// ArfBlocks Dependencies 
builder.Services.AddArfBlocks(options =>
{
	options.ApplicationProjectNamespace = "Application";
	options.ConfigurationSection = builder.Configuration.GetSection("ProjectNameConfigurations");
	options.LogLevel = LogLevels.Warning;
});

string DefaultCorsPolicy = "DefaultCorsPolicy";
builder.Services.AddCors(options =>
			{
				// Development Cors Policy
				options.AddPolicy(name: DefaultCorsPolicy,
					builder =>
					{
						builder.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowAnyOrigin();
					});
			});


var app = builder.Build();

app.UseCors(DefaultCorsPolicy);

app.UseArfBlocksRequestHandlers((Action<UseRequestHandlersOptions>)(options =>
{
	options.AuthorizationType = UseRequestHandlersOptions.AuthorizationTypes.Jwt;
	options.AuthorizationPolicy = UseRequestHandlersOptions.AuthorizationPolicies.AssumeAllAuthorized;
	options.JwtAuthorizationOptions = new UseRequestHandlersOptions.JwtAuthorizationOptionsModel()
	{
		Audience = JwtService.Audience,
		Secret = JwtService.Secret,
	};
}));

app.Run();

