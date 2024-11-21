namespace lab6.Models
{
    public class ShipmentProductAndService
    {
        public int ShipmentId { get; set; }
        public int ProductSvcId { get; set; }
        public int Quantity { get; set; }

        public Shipment Shipment { get; set; }
        public ProductAndService ProductSvc { get; set; }
    }
}
