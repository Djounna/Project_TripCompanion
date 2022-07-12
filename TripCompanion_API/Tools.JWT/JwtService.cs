using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tools.JWT
{
    public class JwtService
    {
        private readonly JwtConfig _jwtConfig;
        private readonly JwtSecurityTokenHandler _handler;
        public JwtService(JwtConfig jwtConfig, JwtSecurityTokenHandler handler)
        {
            _jwtConfig = jwtConfig;
            _handler = handler;
        }
        public string CreateToken(string role, string username)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(
                // issuer
                _jwtConfig.Issuer,
                // audience
                _jwtConfig.Audience,
                // claims,
                CreateClaims(role, username),
                // nbf,
                DateTime.Now,
                // exp,
                DateTime.Now.AddSeconds(_jwtConfig.Duration),
                // signature
                CreateSignature()
            );
            return _handler.WriteToken(jwt);
        }
        private SigningCredentials CreateSignature()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Signature)),
                SecurityAlgorithms.HmacSha256
            );
        }
        private IEnumerable<Claim> CreateClaims(string role, string username)
        {
            yield return new Claim(ClaimTypes.Role, role);
            yield return new Claim(ClaimTypes.NameIdentifier, username);
        }
        public ClaimsPrincipal ValidateToken(string token)
        {
            return _handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtConfig.Issuer,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey
                    = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Signature))
            }, out SecurityToken securityToken);
        }
    }
}
