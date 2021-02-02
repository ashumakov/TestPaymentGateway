using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PaymentGateway.Hosts.WebApi.Models;

namespace PaymentGateway.Hosts.WebApi.Security
{
    public class ValidateHashAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
    }

    public class ValidateHashAuthenticationHandler : AuthenticationHandler<ValidateHashAuthenticationSchemeOptions>
    {
        private Services.DataContracts.Contracts.IAuthenticationService _authenticationService;

        public ValidateHashAuthenticationHandler(IOptionsMonitor<ValidateHashAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,
            Services.DataContracts.Contracts.IAuthenticationService authenticationService) : base(options, logger, encoder, clock)
        {
            _authenticationService = authenticationService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            BaseRequest model;
            string originalContent;

            if (!Request.Headers.ContainsKey(AuthenticationSchemeConstants.HeaderName))
            {
                return Task.FromResult(AuthenticateResult.Fail("Header Not Found."));
            }

            var token = Request.Headers[AuthenticationSchemeConstants.HeaderName].ToString();

            //read request body
            try
            {
                using (var requestReader = new StreamReader(Request.Body))
                {
                    originalContent = requestReader.ReadToEndAsync().Result;
                    // deserialize stream into token model object
                    model = JsonConvert.DeserializeObject<BaseRequest>(originalContent);
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogError("Exception Occured while Deserializing: " + ex);
                return Task.FromResult(AuthenticateResult.Fail("SignatureParseException"));
            }

            if (model != null)
            {
                //verify request signature
                if (!_authenticationService.AuthenticateMerchant(model.MerchantId, token, originalContent))
                {
                    Logger.LogError("Failed to verify signature.");
                    return Task.FromResult(AuthenticateResult.Fail("SignatureVerificationException"));
                }

                // create claims array from the model
                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, model.MerchantId.ToString()) };

                // generate claimsIdentity on the name of the class
                var claimsIdentity = new ClaimsIdentity(claims,
                            nameof(ValidateHashAuthenticationHandler));

                // generate AuthenticationTicket from the Identity
                // and current authentication scheme
                var ticket = new AuthenticationTicket(
                    new ClaimsPrincipal(claimsIdentity), this.Scheme.Name);

                //put data back
                var requestData = Encoding.UTF8.GetBytes(originalContent);
                Request.Body = new MemoryStream(requestData);

                Logger.LogInformation("");

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail("Model is Empty"));
        }
    }
}