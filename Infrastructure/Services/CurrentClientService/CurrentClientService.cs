namespace Infrastructure.Services
{
	public class CurrentClientService
	{
		private IdentifiedClient _currentClient;
		private ApplicationDbContext _dbContext;

		public CurrentClientService(ClientProvider clientProvider, ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_currentClient = clientProvider._currentClient;
		}

		public Guid GetCurrentUserId()
		{
			return this._currentClient.Id;
		}

		public string GetCurrentUserDisplayName()
		{
			return this._currentClient?.DisplayName;
		}

		public Guid GetCurrentUserDepartmentId()
		{
			if (this._currentClient.UserFromDB == null)
				this._currentClient.UserFromDB = _dbContext.Users.FirstOrDefault(p => p.Id == this._currentClient.Id);

			return this._currentClient?.UserFromDB.DepartmentId ?? Guid.Empty;
		}

		public User GetUser()
		{
			if (this._currentClient.UserFromDB == null)
				this._currentClient.UserFromDB = _dbContext.Users.FirstOrDefault(p => p.Id == this._currentClient.Id);

			return this._currentClient?.UserFromDB;
		}
	}
}
