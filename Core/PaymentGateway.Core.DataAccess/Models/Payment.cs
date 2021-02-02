namespace PaymentGateway.Core.DataAccess.Models
{
    public class Payment : AuditEntity
    {
        public Merchant Owner { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Order { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Amount { get; set; }
        public string BankTansactionId { get; set; }
        public string BankAuthCode { get; set; }
        public string BankStatus { get; set; }
        public string BankStatusCode { get; set; }
    }
}