using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Application.Services
{
    public class AuthMiddleware
    {
        public static string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }  
        public static string GenerateJsonWebToken(User data,  IConfiguration config)  
        {  
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);  
            
            var claims = new[] {  
                new Claim(JwtRegisteredClaimNames.Sid, data.Id.ToString()), 
                new Claim(JwtRegisteredClaimNames.Email, data.Email),  
                new Claim(JwtRegisteredClaimNames.GivenName, data.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, data.LastName),
                new Claim("Roles", data.RoleId.ToString()), 
            }; 
  
            var token = new JwtSecurityToken(config["Jwt:Issuer"],  
                config["Jwt:Issuer"],  
                claims,  
                expires: DateTime.Now.AddMinutes(120),  
                signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }

        public static int GetUserId(ClaimsPrincipal User)
        {
            var claimsIdentity = GetClaim(User);
            var userId = claimsIdentity.Claims.Where(x => x.Type == "sid").FirstOrDefault().Value;
            return Int32.Parse(userId);
        }

        public static ClaimsIdentity GetClaim(ClaimsPrincipal User)
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}