namespace lab6.Models
{
    public class ProductAndServiceType
    {
        public string ProductSvcTypeCode { get; set; }
        public string ProductSvcTypeDescription { get; set; }

        public ICollection<ProductAndService> ProductsAndServices { get; set; }
    }
}
