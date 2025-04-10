namespace Application.Configurations
{
	public class ApplicationDependencyProvider : ArfBlocksDependencyProvider
	{
		public ApplicationDependencyProvider(IHttpContextAccessor httpContextAccessor, ProjectConfigurations projectConfigurations, Logger logger)
		{
			base.Add<ArfBlocksDependencyProvider>(this);
			base.Add<RelationalDbConfiguration>(projectConfigurations.RelationalDbConfiguration);
			base.Add<EnvironmentConfiguration>(projectConfigurations.EnvironmentConfiguration);
			base.Add<IHttpContextAccessor>(httpContextAccessor);
			base.Add<CurrentUserModel>(new CurrentUserModel());
			base.Add<Logger>(logger);

			base.Add<ApplicationDbContext>();
			base.Add<DbValidationService>();
			base.Add<DbVerificationService>();
			base.Add<EnvironmentService>();
			base.Add<CustomDbContextOptions>();
			base.Add<CurrentUserService>();
			base.Add<IJwtService, JwtService>();
			base.Add<CustomLogger>();
		}
	}
}
