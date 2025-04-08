var builder = WebApplication.CreateBuilder(args);

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectNameConfigurations").Get<ProjectConfigurations>();
var environmentService = new EnvironmentService(configurations.EnvironmentConfiguration);
var dbContext = new ApplicationDbContext(new CustomDbContextOptions(configurations.RelationalDbConfiguration, environmentService));
builder.Services.AddSingleton<ApplicationDbContext>(dbContext);

/*var defaultSeeder = new DefaultSeeder(dbContext);
await defaultSeeder.Seed();
System.Console.WriteLine("Default DB Seeding Completed.");*/

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

