using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PaymentGateway.Core.DataAccess.Models;
using PaymentGateway.Services.Contracts;
using PaymentGateway.Services.DataContracts.Contracts;
using PaymentGateway.Services.DataContracts.Models;
using PaymentGateway.Services.DataContracts.Models.BankDto;

namespace PaymentGateway.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAcquiringBankService _bankService;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IAcquiringBankService bankService, ILogger<PaymentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bankService = bankService;
            _logger = logger;
        }

        public PaymentResult RetrievePayment(RetrievePaymentRequest retrievePaymentRequest)
        {
            var paymentEntity = _unitOfWork.Payment
                                                .QueryAsync(p => p.Id == retrievePaymentRequest.PaymentId && p.Owner.Id == retrievePaymentRequest.MerchantId)
                                                .Result.FirstOrDefault();
            if (paymentEntity != null)
            {
                return _mapper.Map<PaymentResult>(paymentEntity);
            }

            return null;
        }

        public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            var merchantEntity = await _unitOfWork.Merchants.GetAsync(paymentRequest.MerchantId);
            var paymentEntity = await SavePaymentRequestDetailsAsync(paymentRequest, merchantEntity);

            //call bank
            var bankResponse = TransferMoneyToMerchant(paymentRequest, merchantEntity);

            //map back to db
            paymentEntity = await SaveBankResponseToPaymentAsync(bankResponse, paymentEntity);

            return _mapper.Map<PaymentResult>(paymentEntity);
        }

        private async Task<Payment> SaveBankResponseToPaymentAsync(BankResponse bankResponse, Payment paymentEntity)
        {
            paymentEntity = _mapper.Map<BankResponse, Payment>(bankResponse, paymentEntity);
            _unitOfWork.Payment.Update(paymentEntity);
            await _unitOfWork.CommitAsync();
            return paymentEntity;
        }

        private BankResponse TransferMoneyToMerchant(PaymentRequest paymentRequest, Merchant merchantEntity)
        {
            BankResponse response;
            try
            {
                response = _bankService.TransferMoney(_mapper.Map<BankAccount>(merchantEntity), _mapper.Map<BankAccount>(paymentRequest));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error processing bank transaction");
                response = new BankResponse {Status = "Bank processing failed", StatusCode = "Error"};
            }

            return response;
        }

        private async Task<Payment> SavePaymentRequestDetailsAsync(PaymentRequest paymentRequest, Merchant merchantEntity)
        {
            var paymentEntity = _mapper.Map<Payment>(paymentRequest);
            
            if (merchantEntity != null)
            {
                paymentEntity.Owner = merchantEntity;
                _unitOfWork.Payment.Create(paymentEntity);
                await _unitOfWork.CommitAsync();
            }

            return paymentEntity;
        }
    }
}