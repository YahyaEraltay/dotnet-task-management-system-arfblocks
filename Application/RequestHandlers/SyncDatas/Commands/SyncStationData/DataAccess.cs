namespace Application.RequestHandlers.SyncDatas.Commands.SyncStationData
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task<Guid> GetStationIdByLicenseNoAndSubLicenseNo(string licenseNo, string subLicenseNo)
        {
            return await _dbContext.Stations.Where(t => t.LicenseNo == licenseNo && t.SubLicenseNo == subLicenseNo).Select(t => t.Id).FirstOrDefaultAsync();
        }

        public async Task<List<TankGroup>> TankGroupByStationId(Guid stationId)
        {
            return await _dbContext.TankGroups.Where(t => t.StationId == stationId).ToListAsync();
        }

        public async Task Add(TankGroup tankGroup)
        {
            _dbContext.TankGroups.Add(tankGroup);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(TankGroup tankGroup)
        {
            _dbContext.TankGroups.Update(tankGroup);
            await _dbContext.SaveChangesAsync();
        }
    }
}