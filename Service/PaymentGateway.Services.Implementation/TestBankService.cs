using System;
using System.Linq;
using PaymentGateway.Services.DataContracts.Contracts;
using PaymentGateway.Services.DataContracts.Models.BankDto;

namespace PaymentGateway.Services.Implementation
{
    public class TestBankService : IAcquiringBankService
    {
        public BankResponse TransferMoney(BankAccount targetAccount, BankAccount sourceAccount)
        {
            
            //simulate bank response
            var randomResponse = new Random().Next(0, 5);

            return randomResponse switch
            {
                0 => SuccessResult(),
                1 => InvalidCardNumber(),
                2 => DeclinedTransaction(),
                _ => SuccessResult()
            };
        }

        private static BankResponse InvalidCardNumber()
        {
            return new BankResponse
            {
                Status = "InvalidCard",
                StatusCode = "Error"
            };
        }

        private static BankResponse DeclinedTransaction()
        {
            return new BankResponse
            {
                Status = "DeclinedTransaction",
                StatusCode = "Error"
            };
        }

        private static BankResponse SuccessResult()
        {
            return new BankResponse
            {
                Status = "Accepted",
                StatusCode = "Success",
                TransactionId = Guid.NewGuid().ToString(),
                AuthCode = RandomString(8)
            };
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}