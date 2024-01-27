using AmericanAuto.Database.Entities.Base;
using AmericanAuto.Database.Entities.Enums;

namespace AmericanAuto.Database.Entities
{
    public class Customer : BaseEntity
    {
        // Properties for Customer Information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Description { get; set; }

        // Properties for Address
        public string Country { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public string PostCode { get; set; }

        public OrderType OrderType { get; set; }

        // Navigation property
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
