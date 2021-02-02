namespace PaymentGateway.Services.DataContracts.Models.BankDto
{
    public class BankResponse
    {
        public string TransactionId { get; set; }
        public string AuthCode { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
    }
}