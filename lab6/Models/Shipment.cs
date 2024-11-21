namespace lab6.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int FromOrganizationId { get; set; }
        public int ToOrganizationId { get; set; }
        public string ShipmentDetails { get; set; }

        public Organization FromOrganization { get; set; }
        public Organization ToOrganization { get; set; }
        public ICollection<ShipmentProductAndService> ShipmentProducts { get; set; }
        public ICollection<MovementLocation> MovementLocations { get; set; }
    }
}
