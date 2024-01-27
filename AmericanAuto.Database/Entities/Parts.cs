using AmericanAuto.Database.Entities.Base;
using AmericanAuto.Database.Entities.Enums;

namespace AmericanAuto.Database.Entities
{
    public class Parts : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string PartCode { get; set; }
        public PartConditionType PartConditionType { get; set; }
        public string FromCountry { get; set; }

        // Foreign key property
        public int VehicleId { get; set; }

        // Navigation property
        public virtual Vehicle Vehicle { get; set; }
    }
}
