using AutoMapper;
using Newtonsoft.Json;

namespace PaymentGateway.Services.Implementation.Util
{
    public class SerializeJsonTypeConverter<T> : ITypeConverter<T, string>
    {
        public string Convert(T source, string destination, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source);
        }
    }
}
