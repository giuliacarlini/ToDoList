using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Authentication;

public static class JwtAuth
{
    private static RandomNumberGenerator _rgn = RandomNumberGenerator.Create();
    private static readonly string MyJwkLocation = Path.Combine(Environment.CurrentDirectory, "key.json");

    public static string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = LoadKey();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, "admin")
            }),
            Expires = DateTime.UtcNow.AddHours(3),

            SigningCredentials =
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private static SecurityKey? LoadKey()
    {
        JsonWebKey? tokenJwt;

        if (File.Exists(MyJwkLocation))
        {
            tokenJwt = JsonSerializer.Deserialize<JsonWebKey>(File.ReadAllText(MyJwkLocation));
        }
        else
        {
            tokenJwt = CreateJWK();
            File.WriteAllText(MyJwkLocation, JsonSerializer.Serialize<JsonWebKey>(tokenJwt));
        }

        return tokenJwt;
    }

    public static bool ValidateToken(string apiToken, out string errorMessage)
    {
        errorMessage = "";

        var key = LoadKey();

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(apiToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
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

    private static JsonWebKey CreateJWK()
    {
        var symetricKey = new HMACSHA256(GenerateKey(64));
        var jwk = JsonWebKeyConverter.ConvertFromSymmetricSecurityKey(new SymmetricSecurityKey(symetricKey.Key));
        jwk.KeyId = Base64UrlEncoder.Encode(GenerateKey(16));
        return jwk;
    }

    private static byte[] GenerateKey(int bytes)
    {
        var data = new byte[bytes];
        _rgn.GetBytes(data);
        return data;
    }
}
