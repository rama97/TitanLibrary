
using Microsoft.Extensions.Configuration;

namespace Tools
{
    public class Config
    {
        public static IConfiguration configuration;

        public static string SqlDarabaseConnectionString
        {
            get { return configuration.GetValue<string>("ConnectionStrings:Database"); }
        }

        #region JWT
        public static string JWTKey
        {
            get { return configuration.GetValue<string>("JwtSettings:SecretKey"); }
        }

        public static string JWTAudiance
        {
            get { return configuration.GetValue<string>("JwtSettings:Audience"); }
        }

        public static string JWTIssuer
        {
            get { return configuration.GetValue<string>("JwtSettings:Issuer"); }
        }

        public static int JWTExpInMin
        {
            get { return configuration.GetValue<int>("JwtSettings:ExpiresInMinutes"); }
        }

        #endregion JWT


    }
}
