using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HareketRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IOptions<MyAppConfig> _config;

        public AuthController(IOptions<MyAppConfig> config)
        {
            this._config = config;
        }

        [HttpPost, Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel user) {
            if (user == null)
                return BadRequest("Geçersiz kullanıcı talebi");

            if (user.UserName == "admin" && user.Password == "sifre") {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Secret));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, Role.Admin)
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: _config.Value.BaseSiteRoot,
                    audience: _config.Value.BaseSiteRoot,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
