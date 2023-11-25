using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain;

public static class JwtAuth
{
    public static string GenerateToken(User user, string tokenJwt, int seconds)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(tokenJwt);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Name)
            }),
            Expires = DateTime.UtcNow.AddSeconds(seconds),

            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public static bool ValidateToken(string? tokenJwt, string apiToken, out string errorMessage)
    {
        errorMessage = "";

        if (tokenJwt == null)
            return false;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(tokenJwt);
        try
        {
            tokenHandler.ValidateToken(apiToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            return true;
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
            return false;
        }
    }
}

public class TokenConfigurations
{
    public string? Audience { get; set; }
    public string? Issuer { get; set; }
    public int Seconds { get; set; }
    public string? SecretJwtKey { get; set; }
}