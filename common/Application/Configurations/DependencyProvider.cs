namespace TodoApp.Application.Configuration
{
	public class ApplicationDependencyProvider : ArfBlocksDependencyProvider
	{
		public ApplicationDependencyProvider(IHttpContextAccessor httpContextAccessor, ProjectNameConfigurations projectConfigurations)
		{
			// Instances
			base.Add<RelationalDbConfiguration>(projectConfigurations.RelationalDbConfiguration);
			base.Add<EnvironmentConfiguration>(projectConfigurations.EnvironmentConfiguration);
			base.Add<IHttpContextAccessor>(httpContextAccessor);
			//base.Add<IdentifiedClient>(new IdentifiedClient());

			// Types
			base.Add<ApplicationDbContext, ApplicationDbContext>();
			base.Add<DbValidationService, DbValidationService>();
			base.Add<EnvironmentService, EnvironmentService>();
			base.Add<CustomDbContextOptions, CustomDbContextOptions>();
			//base.Add<ClientProvider, ClientProvider>();
			//base.Add<CurrentClientService, CurrentClientService>();
			base.Add<IJwtService, JwtService>();
			//base.Add<ActivityLogService, ActivityLogService>();
		}
	}
}
