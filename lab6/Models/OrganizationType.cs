namespace lab6.Models
{
    public class OrganizationType
    {
        public string OrganizationTypeCode { get; set; }
        public string OrganizationTypeDescription { get; set; }

        public ICollection<Organization> Organizations { get; set; }
    }
}
