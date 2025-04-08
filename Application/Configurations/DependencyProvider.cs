namespace Application.Configurations
{
	public class ApplicationDependencyProvider : ArfBlocksDependencyProvider
	{
		public ApplicationDependencyProvider(IHttpContextAccessor httpContextAccessor, ProjectConfigurations projectConfigurations)
		{
			base.Add<RelationalDbConfiguration>(projectConfigurations.RelationalDbConfiguration);
			base.Add<EnvironmentConfiguration>(projectConfigurations.EnvironmentConfiguration);
			base.Add<IHttpContextAccessor>(httpContextAccessor);
			base.Add<IdentifiedClient>(new IdentifiedClient());

			base.Add<ApplicationDbContext>();
			base.Add<DbValidationService>();
			base.Add<EnvironmentService>();
			base.Add<CustomDbContextOptions>();
			base.Add<ClientProvider>();
			base.Add<CurrentClientService>();
			base.Add<IJwtService, JwtService>();
			//TODO: burdaki servicelerin namespaceleri eklenecek.
		}
	}
}
