using System.Threading.Tasks;
using PaymentGateway.Services.DataContracts.Models;

namespace PaymentGateway.Services.Contracts
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPaymentAsync(PaymentRequest retrievePaymentRequest);
        PaymentResult RetrievePayment(RetrievePaymentRequest retrievePaymentRequest);
    }
}