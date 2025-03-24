using Database.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Tools;

namespace Logic.Tools
{
    public static class JwtService
    {
        public static string GenerateJWTToken(User _user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Config.JWTKey);

            var claims = new ClaimsIdentity(new[] {
                    new Claim("Id", _user.Id.ToString()),
                  
                });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(Config.JWTExpInMin),
                Issuer = Config.JWTIssuer,
                Audience = Config.JWTAudiance,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static long GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Config.JWTKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var principal = JwtService.VerifyJWT(jwtToken);

                return VerifyJWT(jwtToken);
            }
            catch (Exception)
            {
                throw new InvalidCredentialException("Invalid Token.");
            }
        }

        public static long VerifyJWT(JwtSecurityToken jwtToken)
        {
            try
            {
                return long.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
            }
            catch (Exception) {
                throw new InvalidCredentialException("Invalid Token.");
            }
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber).Replace('+', '-').Replace('/', '_');
            }
        }
    }
}
