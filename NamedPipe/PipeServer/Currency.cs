namespace PipeServer
{
    public class Currency
    {
        public string CountryCode { get; set; }
        public int ExchangeRate { get; set; }

        public Currency(string countryCode, int exchangeRate)
        {
            CountryCode = countryCode;
            ExchangeRate = exchangeRate;
        }
    }
}