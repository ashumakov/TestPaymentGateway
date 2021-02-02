using PaymentGateway.Services.DataContracts.Models.BankDto;

namespace PaymentGateway.Services.DataContracts.Contracts
{
    public interface IAcquiringBankService
    {
        BankResponse TransferMoney(BankAccount targetAccount, BankAccount sourceAccount);
    }
}