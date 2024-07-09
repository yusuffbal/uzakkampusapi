using Core.Dtos;
using Core.Repositories;
using Core.Services;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Dtos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthenticationService
        (IUserService _userService,
        IConfiguration _configuration
        ) : IAuthenticationService
    {


        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            var user = await _userService.GetUserByEmailAndPasswordAsync(loginDto);
            if (user == null)
            {
                return Response<TokenDto>.Fail("UserNotFound", 400, true);
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Email, loginDto.Email) },
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // TokenDto oluştur
            var tokenDto = new TokenDto
            {
                AccessToken = tokenString,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])), 
                RefreshToken = "refresh_token_value_here",
                RefreshTokenExpiration = DateTime.UtcNow.AddDays(7) 
            };

            return Response<TokenDto>.Success(tokenDto, 200);
        }

    }
}
