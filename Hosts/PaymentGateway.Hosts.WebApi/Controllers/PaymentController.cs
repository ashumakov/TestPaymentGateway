using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PaymentGateway.Hosts.WebApi.Models;
using PaymentGateway.Hosts.WebApi.Security;
using PaymentGateway.Services.Contracts;

namespace PaymentGateway.Hosts.WebApi.Controllers
{
    /// <summary>
    /// Controller allows submit payment for processing and retrieve info for previous payments
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public PaymentController(IMapper mapper, IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }

        /// <summary>
        /// Submit payment information for processing
        /// </summary>
        /// <param name="request">Request contain all necessary information for payment</param>
        /// <returns >A newly created Payment information</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpPost("submit")]
        [ProducesResponseType(typeof(PaymentResult), 200)]
        public async Task<ActionResult> SubmitPayment([FromBody]PaymentRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _paymentService.ProcessPaymentAsync(_mapper.Map<Services.DataContracts.Models.PaymentRequest>(request));

            return Ok(_mapper.Map<PaymentResult>(result));
        }

        /// <summary>
        /// Retrieves the details of a Payment that has previously been created
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("retrieve")]
        [ProducesResponseType(typeof(PaymentResult), 200)]
        [ProducesResponseType(404)]
        public ActionResult RetrievePaymentInfo([FromBody]RetrievePaymentRequest request)
        {
            var result = _paymentService.RetrievePayment(_mapper.Map<Services.DataContracts.Models.RetrievePaymentRequest>(request));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PaymentResult>(result));
        }
    }
}
