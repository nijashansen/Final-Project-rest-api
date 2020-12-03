using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinalProjectAPI.Helpers
{
    public class JwtSecutiryKey
    {
        private static byte[] secretBytes = Encoding.UTF8.GetBytes("A secret for HmacSha256");

        public static SymmetricSecurityKey key
        {
            get { return new SymmetricSecurityKey(secretBytes); }
        }

        public static void SetSecret(string secret)
        {
            secretBytes = Encoding.UTF8.GetBytes(secret);
        }
    }
}
