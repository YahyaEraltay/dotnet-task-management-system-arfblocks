using Domain.Base;

namespace Domain.Entities
{
    public class TankGroup : BaseEntity
    {
        public string Name { get; set; }

        public Guid TableUniqueId { get; set; }

        public Station Station { get; set; }
        public Guid StationId { get; set; }
    }
}