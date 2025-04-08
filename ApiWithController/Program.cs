var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectNameConfigurations").Get<ProjectConfigurations>();
var environmentService = new EnvironmentService(configurations.EnvironmentConfiguration);
var dbContext = new ApplicationDbContext(new CustomDbContextOptions(configurations.RelationalDbConfiguration, environmentService));
builder.Services.AddSingleton<ApplicationDbContext>(dbContext);

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



// 	// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Audience = JwtService.Audience;
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtService.Secret)),
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = true,
        };

        var handler = new JwtSecurityTokenHandler();
        handler.InboundClaimTypeMap.Clear();
    });

environmentService = new EnvironmentService(configurations.EnvironmentConfiguration);

builder.Services.AddSwaggerGen(c =>
{
    c.AddServer(new OpenApiServer() { Url = environmentService.ApiUrl, Description = environmentService.EnvironmentName });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiWithController", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.CustomSchemaIds(x => x.FullName);

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme()
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer"
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"{environmentService.ApiUrl}/swagger/v1/swagger.json", "TodoApp.Api v1");
});

app.UseCors(DefaultCorsPolicy);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


// // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
// public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
// {
// 	if (env.EnvironmentName == "Development")
// 	{
// 		app.UseDeveloperExceptionPage();
// 	}

// 	app.UseSwagger();
// 	app.UseSwaggerUI(c =>
// 	{
// 		c.SwaggerEndpoint($"{environmentService.ApiUrl}/swagger/v1/swagger.json", "TodoApp.Api v1");
// 	});

// 	app.UseCors(DefaultCorsPolicy);

// 	app.UseRouting();

// 	app.UseAuthentication();
// 	app.UseAuthorization();

// 	app.UseEndpoints(endpoints =>
// 	{
// 		endpoints.MapControllers()
// 				 .RequireAuthorization();  // Automatically add [Authorize] to all Controllers
// 	});
// }
