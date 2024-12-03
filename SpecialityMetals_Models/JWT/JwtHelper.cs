using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Speciality_Metals_Back_End.SpecialityMetals_Models.JWT;


namespace Speciality_Metals_Back_End.SpecialityMetals_Models.JWT
{
    public class JwtHelper
    {
        private readonly JWTSettings _jwtSettings;

        public JwtHelper(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateJwtToken(string employeeCode)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)); // Ensure the key is at least 256 bits
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, employeeCode),
                    // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
