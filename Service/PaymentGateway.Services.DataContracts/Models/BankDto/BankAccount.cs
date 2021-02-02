namespace PaymentGateway.Services.DataContracts.Models.BankDto
{
    public class BankAccount
    {
        public string AccountOwnerName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountSecurityCode { get; set; }
        public string AccountExpirationDate { get; set; }
    }
}