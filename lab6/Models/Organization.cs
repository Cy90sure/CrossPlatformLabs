namespace lab6.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationTypeCode { get; set; }
        public string OrganizationDetails { get; set; }

        public OrganizationType OrganizationType { get; set; }
        public ICollection<Shipment> ShipmentsFrom { get; set; }
        public ICollection<Shipment> ShipmentsTo { get; set; }
    }
}
