namespace Infrastructure.Services;

public interface IJwtService
{
	string GenerateJwt(User user);
	int GetExpirationDayCount();
}