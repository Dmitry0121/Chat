using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Chat
{
    public class AuthOptions
    {
        public const string ISSUER = "MyToken";
        public const string AUDIENCE = "http://localhost:11906/";
        const string KEY = "secret_key_!@#$%^^&*()_";
        public const int LIFETIME = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}