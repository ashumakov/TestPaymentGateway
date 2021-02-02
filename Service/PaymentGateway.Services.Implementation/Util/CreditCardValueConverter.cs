using System.Text;
using AutoMapper;

namespace PaymentGateway.Services.Implementation.Util
{
    public class CreditCardValueConverter : IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context)
        {
            var sb = new StringBuilder(sourceMember.Length);
            for (var i = 0; i < sourceMember.Length; i++)
            {
                if (i > 0 && i < sourceMember.Length - 4)
                {
                    sb.Append('x');
                }
                else
                {
                    sb.Append(sourceMember[i]);
                }
            }

            return sb.ToString();
        }
    }
}