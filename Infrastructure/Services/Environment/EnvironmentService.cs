namespace Infrastructure.Services;

public class EnvironmentService
{
    public string EnvironmentName { get; }
    public CustomEnvironments Environment { get; }
    public string ApiUrl { get; }
    public string UiUrl { get; }

    public EnvironmentService(EnvironmentConfiguration configuration)
    {
        switch (configuration.EnvironmentName)
        {
            case "Production":
                this.Environment = CustomEnvironments.Production;
                this.ApiUrl = "http://localhost:5257";
                break;
            case "Staging":
                this.Environment = CustomEnvironments.Staging;
                this.ApiUrl = "http://localhost:5257";
                break;
            case "Development":
                this.Environment = CustomEnvironments.Development;
                this.ApiUrl = "http://localhost:5257";
                break;
            case "Test":
                this.Environment = CustomEnvironments.Test;
                this.ApiUrl = "no-url";
                this.UiUrl = "no-url";
                break;
        }

        this.EnvironmentName = configuration.EnvironmentName;

        System.Console.WriteLine(ApiUrl);
        System.Console.WriteLine(EnvironmentName);
    }
}

