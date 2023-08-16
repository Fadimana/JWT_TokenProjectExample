using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_TokenExample.Security
{
    public class TokenValidation 
    {
        public static List<Claim> tokenValidation(string token,IConfiguration configuration)
        {

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])); //keyimizi burda da tanımlamamız gerekir. 

            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    ValidateIssuer = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims.ToList();
                return claims;
            }
            catch
            {
                return new List<Claim>();
            }
        }

    }
}
