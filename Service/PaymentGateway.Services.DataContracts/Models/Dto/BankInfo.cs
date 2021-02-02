namespace PaymentGateway.Services.DataContracts.Models
{
    public class BankInfo
    {
        public string TansactionId { get; set; }
        public string AuthCode { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
    }
}