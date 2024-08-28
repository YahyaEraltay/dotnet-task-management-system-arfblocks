using System;
using Domain.Entities;

namespace Infrastructure.Services
{
	public interface IJwtService
	{
		string GenerateJwt(User user);
		int GetExpirationDayCount();
	}
}
