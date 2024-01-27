using AmericanAuto.Database.Entities.Base;
using AmericanAuto.Database.Entities.Enums;

namespace AmericanAuto.Database.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public string EngineSize { get; set; }
        public TransmissionType Transmission {  get; set; }
        public FuelType FuelType { get; set; }
        public string Description { get; set; }
        public string Vin { get; set; }

        // Foreign key property
        public int CustomerId { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Parts> Parts { get; set; }
    }
}
