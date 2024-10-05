namespace Application.RequestHandlers.SyncDatas.Commands.SyncStationData
{
    public class ResponseModel : IResponseModel
    {
        public bool IsEverythingOk { get; set; }
    }

    public class RequestModel : IRequestModel
    {
        public string LicenseNo { get; set; }
        public string SubLicenseNo { get; set; }

        public List<TankGroupRequestModel> TankGroups { get; set; }

        public class TankGroupRequestModel
        {
            public string Name { get; set; }
            public Guid TableUniqueId { get; set; }
        }
    }
}