﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LibraryManegerBackend.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MessangerBackend;

public static class JwtGenerator
{
    public static string GenerateJwt(User user, string token, DateTime expiryDate)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var jwtToken = new JwtSecurityToken(
            claims: claims,
            expires: expiryDate,
            signingCredentials: creds);
        
        var jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return jwt;
    }
}