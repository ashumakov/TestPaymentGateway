using AutoMapper;
using Newtonsoft.Json;

namespace PaymentGateway.Services.Implementation.Util
{
    public class DeserializeJsonTypeConverter<T> : ITypeConverter<string, T>
    {
        public T Convert(string source, T destination, ResolutionContext context)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
}