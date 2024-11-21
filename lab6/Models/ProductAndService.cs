namespace lab6.Models
{
    public class ProductAndService
    {
        public int ProductSvcId { get; set; }
        public string ProductSvcTypeCode { get; set; }
        public string ProductSvcDetails { get; set; }
        public int Quantity { get; set; }

        public ProductAndServiceType ProductSvcType { get; set; }
        public ICollection<ShipmentProductAndService> ShipmentProducts { get; set; }
    }
}
