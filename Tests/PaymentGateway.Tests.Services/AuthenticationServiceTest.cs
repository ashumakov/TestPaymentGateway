using System;
using Moq;
using PaymentGateway.Core.DataAccess.Models;
using PaymentGateway.Services.DataContracts.Contracts;
using PaymentGateway.Services.Implementation;
using Xunit;

namespace PaymentGateway.Tests.Services
{
    public class AuthenticationServiceTest
    {
        [Fact]
        public void AuthenticationSuccess()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Merchants.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) =>
                {
                    var merchant = new Merchant();
                    merchant.Id = id;
                    merchant.SigningKey = "someTestSignature";
                    return merchant;
                });

            IAuthenticationService authService = new AuthenticationService(uow.Object);
            
            Assert.True(authService.AuthenticateMerchant(Guid.Empty, "0fa274aacfc27263b107748055570ae207713f356b31ef8cbf9e69773837a2c36dd2a9cd7152f46959cd1c127a7eec6147760465187f458e0ed9a277e0dfba5e", "SomeRequestBodyToVerify"));
        }

        [Fact]
        public void AuthenticationFailed()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Merchants.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) =>
                {
                    var merchant = new Merchant();
                    merchant.Id = id;
                    merchant.SigningKey = "someTestSignature";
                    return merchant;
                });

            IAuthenticationService authService = new AuthenticationService(uow.Object);
            
            Assert.False(authService.AuthenticateMerchant(Guid.Empty, "0fa274aacfc27263b107748055570ae207713f356b31ef8cbf9e69773837a2c36dd2a9cd7152f46959cd1c127a7eec6147760465187f458e0ed9a277e0dfba5e", "SomeRequestBodyToVerifyBadBody"));
        }
    }
}
