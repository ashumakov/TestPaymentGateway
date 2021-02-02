namespace PaymentGateway.Core.DataAccess.Models
{
    public interface IModel<TId>
    {
        TId Id { get; set; }
    }
}
