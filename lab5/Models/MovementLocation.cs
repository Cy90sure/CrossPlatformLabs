namespace lab5.Models
{
    public class MovementLocation
    {
        public int ShipmentLocationId { get; set; }
        public int ShipmentId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; }
        public string OtherDetails { get; set; }
        public Location FromLocation { get; set; }
        public Location ToLocation { get; set; }
    }
}
