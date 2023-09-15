using BestbitePizza.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BestbitePizza.Services
{
    public interface IAuthService
    {
        Token GetToken(Credential credential);
    }

    public class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token GetToken(Credential credential)
        {
            Token token = new();

            if (credential.Username == "admin" && credential.Password == "123456")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin")
                };

                var expiresAt = DateTime.UtcNow.AddMinutes(1);

                token = new()
                {
                    AccessToken = CreateToken(claims, expiresAt),
                    ExpiresAt = expiresAt
                };
            }

            return token;
        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey") ?? string.Empty);

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                ));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }

    public class Token
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow;
    }
}
