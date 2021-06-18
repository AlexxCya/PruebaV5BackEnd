using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaV5.Api.Responses;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;

namespace PruebaV5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        public TokenController(IConfiguration configuration, ISecurityService securityService)
        {
            _configuration = configuration;
            _securityService = securityService;
        }
        /// <summary>
        /// User Authentication to Generate Token
        /// </summary>
        /// <param name="login">Filters to apply</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //if it is a valid user
            var validation = await IsValidateUser(login);
            if (validation.Item1)
            {
                var isValid = validation.Item1;
                var token = GenerateToken(validation.Item2);
                var response = new ApiResponse<string>(token, isValid);
                //return Ok(new { isValid, login.User, token });
                return Ok(response);
            }

            return NotFound();
        }

        private async Task<(bool, Security)> IsValidateUser(UserLogin login)
        {
            var user = await _securityService.GetLoginByCredentials(login);
            return (user != null, user);
        }

        private string GenerateToken(Security security)
        {
            //header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // clims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,security.UserName),
                new Claim("User", security.User),
                new Claim(ClaimTypes.Role,security.Role.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                  _configuration["Authentication:Issuer"],
                  _configuration["Authentication:Audience"],
                  claims,
                  DateTime.Now,
                  DateTime.UtcNow.AddMinutes(10)
            );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
