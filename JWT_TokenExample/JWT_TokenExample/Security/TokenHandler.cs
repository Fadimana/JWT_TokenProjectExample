using DataAccess.Layer.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_TokenExample.Security
{
    public static class TokenHAndler
    {
        public static Token CreateToken(IConfiguration configuration, int id, string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,email),
                new Claim(ClaimTypes.NameIdentifier,id.ToString())

            };

            Token token = new Token();
            //SecurityKey'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşacak token  ayarlarını veriyoruz
            token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(5));
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials,
                claims: claims
               );
            //Token oluşturucu sınıfında bir örnek alıyoruz.
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            //Token üretiyoruz
            token.AccsessToken = handler.WriteToken(securityToken);
            return token;
        }
    }
}

