namespace lab5.Models
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryCurrency { get; set; }
        public string LanguagesSpoken { get; set; }
        public decimal UsdExchangeRate { get; set; }
        public DateTime UsdExchangeDate { get; set; }

    }
}
