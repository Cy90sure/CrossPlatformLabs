namespace lab6.Models
{
    public class LocationType
    {
        public string LocationTypeCode { get; set; }
        public string CountryCode { get; set; }
        public string LocationTypeDescription { get; set; }

        public Country Country { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
