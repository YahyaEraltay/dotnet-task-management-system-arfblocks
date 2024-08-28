namespace Application.Configurations
{

	public class ProjectNameConfigurations : IConfigurationClass
	{
		public EnvironmentConfiguration EnvironmentConfiguration { get; set; }
		public RelationalDbConfiguration RelationalDbConfiguration { get; set; }
		//public DocumentDbConfiguration DocumentDbConfiguration { get; set; }
	}
}