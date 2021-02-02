namespace PaymentGateway.Services.DataContracts.Models
{
    public class OrderDetails
    {
        public OrderItem[] DisplayItems { get; set; }
        public OrderItem Total { get; set; }
    }

    public class OrderItem
    {
        public string Label { get; set; }
        public AmountItem Amount { get; set; }
    }
}