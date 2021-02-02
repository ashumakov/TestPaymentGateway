using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PaymentGateway.Hosts.WebApi.Controllers;
using PaymentGateway.Services.Contracts;
using PaymentGateway.Services.DataContracts.Models;
using Xunit;
using PaymentRequest = PaymentGateway.Hosts.WebApi.Models.PaymentRequest;

namespace PaymentGateway.Tests.Api
{
    public class PaymentControllerTests
    {
        [Fact]
        public void SubmitPaymentSuccessTest()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Services.DataContracts.Models.PaymentRequest>(It.IsAny<PaymentRequest>()))
                .Returns((PaymentRequest source) => new Services.DataContracts.Models.PaymentRequest());

            var paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock.Setup(service =>
                    service.ProcessPaymentAsync(It.IsAny<Services.DataContracts.Models.PaymentRequest>()))
                .ReturnsAsync(() => new PaymentResult());
            var paymentController = new PaymentController(mapperMock.Object, paymentServiceMock.Object);

            var result = paymentController.SubmitPayment(new PaymentRequest()).Result;
         
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void SubmitPaymentFailedTest()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Services.DataContracts.Models.PaymentRequest>(It.IsAny<PaymentRequest>()))
                .Returns((PaymentRequest source) => new Services.DataContracts.Models.PaymentRequest());

            var paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock.Setup(service =>
                    service.ProcessPaymentAsync(It.IsAny<Services.DataContracts.Models.PaymentRequest>()))
                .ReturnsAsync(() => new PaymentResult());
            

            var paymentController = new PaymentController(mapperMock.Object, paymentServiceMock.Object);

            paymentController.ModelState.AddModelError("SessionName", "Required");
            var result = paymentController.SubmitPayment(new PaymentRequest()).Result;
         
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
