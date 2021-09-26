using HareketRehberi.BL.SystemUserBL;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IOptions<MyAppConfig> _config;
        private readonly ISystemUserBL _systemUserBL;

        public AuthController(IOptions<MyAppConfig> config, ISystemUserBL systemUserBL)
        {
            _config = config;
            this._systemUserBL = systemUserBL;
        }

        [HttpPost, Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel user) {
            if (user == null)
                return BadRequest("Geçersiz kullanıcı talebi");

            var userFromDb = await _systemUserBL.GetByUserName(user.UserName);

            if (userFromDb == null) return BadRequest("Geçersiz kullanıcı talebi, geçersiz kullanıcı adı!!!");

            using var hmac = new HMACSHA512(userFromDb.PasswordKey);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userFromDb.PasswordHash[i]) return Unauthorized("Geçersiz Password");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Secret));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var role = userFromDb.IsAdmin ? Role.Admin : Role.User;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _config.Value.BaseSiteRoot,
                audience: _config.Value.BaseSiteRoot,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString, Id = userFromDb.Id });
        }
    }
}
