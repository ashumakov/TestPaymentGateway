namespace PaymentGateway.Services.DataContracts.Models
{
    public class CardPaymentInfo
    {
        public string CardNumber { get; set; }
        public string CardSecurityCode { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
    }
}