using Domain.Base;

namespace Domain.Entities
{
    public class Station : BaseEntity
    {
        public string Name { get; set; }
        public string LicenseNo { get; set; }
        public string SubLicenseNo { get; set; }

    }
}