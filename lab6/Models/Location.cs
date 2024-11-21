namespace lab6.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationTypeCode { get; set; }
        public string LocationAddress { get; set; }
        public string OtherDetails { get; set; }

        public LocationType LocationType { get; set; }
        public ICollection<MovementLocation> MovementLocationsFrom { get; set; }
        public ICollection<MovementLocation> MovementLocationsTo { get; set; }
    }
}
