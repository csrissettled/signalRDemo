﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace signalR_server {
    public class Utils {

        public static string AccessSecret = "asfdasgw2324wr23rfwfsafasd";
        public static string Issuer = "asfdsf";
        public static string Audience = "dfdsfasdf";
        public static int AccessExpiration = 60 ;
        public static string GenerateAccessToken(string username) {
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("username", username), 
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AccessSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtAccessToken = new JwtSecurityToken(Issuer, Audience, claims,
                expires: DateTime.Now.AddSeconds(AccessExpiration), signingCredentials: credentials,
                notBefore: DateTime.Now);
            return new JwtSecurityTokenHandler().WriteToken(jwtAccessToken);
        }
    }
}
