namespace Application.RequestHandlers.SyncDatas.Commands.SyncStationData
{
    [AllowAnonymousHandler]
    public class Handler : IRequestHandler
    {
        private readonly DataAccess dataAccessLayer;

        public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
        {
            dataAccessLayer = (DataAccess)dataAccess;
        }

        public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
        {
            var mapper = new Mapper();
            var requestPayload = (RequestModel)payload;

            var stationId = await dataAccessLayer.GetStationIdByLicenseNoAndSubLicenseNo(requestPayload.LicenseNo, requestPayload.SubLicenseNo);
            var tankGroups = await dataAccessLayer.TankGroupByStationId(stationId);

            var matchedTankGroups = requestPayload.TankGroups.Where(t => tankGroups.Any(existingTankGroup => existingTankGroup.TableUniqueId == t.TableUniqueId)).ToList();
            var addedTankGroups = requestPayload.TankGroups.Where(t => !tankGroups.Any(existingTankGroup => existingTankGroup.TableUniqueId == t.TableUniqueId)).ToList();

            var updatedTankGroups = mapper.MapToUpdateTankGroups(tankGroups, matchedTankGroups);
            var newTankGroups = mapper.MapToNewEntity(addedTankGroups, stationId);

            foreach (var updatedTankGroup in updatedTankGroups)
            {
                await dataAccessLayer.Update(updatedTankGroup);
            }

            foreach (var newTankGroup in newTankGroups)
            {
                await dataAccessLayer.Add(newTankGroup);
            }

            var response = mapper.MapToResponse(true);
            return ArfBlocksResults.Success(response);
        }
    }
}