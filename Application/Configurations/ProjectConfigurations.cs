namespace Application.Configurations
{

	public class ProjectConfigurations : IConfigurationClass
	{
		public EnvironmentConfiguration EnvironmentConfiguration { get; set; }
		public RelationalDbConfiguration RelationalDbConfiguration { get; set; }
	}
}