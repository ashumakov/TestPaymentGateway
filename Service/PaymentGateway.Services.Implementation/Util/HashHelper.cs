using System.Security.Cryptography;
using System.Text;

namespace PaymentGateway.Services.Implementation.Util
{
    public static class HashHelper
    {
        public static string CalculateSHA512Hash(string input)
        {
            using (var shaM = new SHA512Managed())
            {
                var data = Encoding.UTF8.GetBytes(input);    
                var hash = shaM.ComputeHash(data);

                var stringBuilder = new StringBuilder(hash.Length * 2);
			
                // computing hashSh1
                foreach (byte b in hash)
                {
                    // "x2"
                    stringBuilder.Append(b.ToString("X2").ToLower());
                }
                return stringBuilder.ToString();
            }
        }
        
    }
}