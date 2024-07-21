using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly Database db;
        private readonly ApiSetting _setting;
     
        private readonly IConfiguration _configuration;
        public LoginController( Database _db, IOptionsMonitor<ApiSetting> options, IConfiguration configuration )
        { db = _db; _setting = options.CurrentValue; _configuration = configuration;}

        [HttpPost("Login")]

        public async Task<IActionResult> LoginUser(Login user)
        {
            var check = db.Users.FirstOrDefault(a => a.Email == user.Email);
            var checkrole = db.Roles.FirstOrDefault(x => x.Id == check.maQuyen);
            if(check !=null && checkrole.Name==user.Role && BCrypt.Net.BCrypt.Verify(user.Password,check.Password))
            {
                var token =  await CreateToken(check);
            var refreshToken = GenerateRefreshToken();
               SetRefreshToken(token);
                return Ok(token);
            }

            return Unauthorized();
        }

        private void SetRefreshToken(TokenViewModel  newRefreshToken)
        {

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(15),

            };
            var cookieOptions2 = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(1),

            };
            Response.Cookies.Append("jwtCookie", newRefreshToken.Accesstoken, cookieOptions);
            Response.Cookies.Append("Refresh", newRefreshToken.RefreshToken, cookieOptions2);
        }
        [HttpPost("Logout")]
        public async Task<ActionResult<string>> Logout()
        {
            Response.Cookies.Delete("jwtCookie");
            return Ok("Da Dang Xuat");
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(TokenViewModel model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:SecretKey").Value!);
            var tokenValidateParam = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false,
            };
            try
            {
               
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.Accesstoken, tokenValidateParam, out var validatedToken);
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return Ok(new TrangThaiViewModel
                        {
                            Success = false,
                            Message = "Tonken Không hợp lệ"
                        });
                    }
                }
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ChuyenDoi(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Ok(new TrangThaiViewModel
                    {
                        Success = false,
                        Message = "Token Chưa hết hạn "
                    });
                }
                var storedToken = db.RefreshTokens.FirstOrDefault(x => x.Token == model.RefreshToken);
                if (storedToken == null)
                {
                    return Ok(new TrangThaiViewModel
                    {
                        Success = false,
                        Message = "Token Không tồn tại"
                    });
                }
                if (storedToken.IsUsed)
                {
                    return Ok(new TrangThaiViewModel
                    {
                        Success = false,
                        Message = "Token Đã Được sữ dụng rồi"
                    });
                }
                if (storedToken.IsRevoked)
                {
                    return Ok(new TrangThaiViewModel
                    {
                        Success = false,
                        Message = "Đã thu hồi "
                    });
                }              
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.idJwt != jti)
                {
                    return Ok(new TrangThaiViewModel
                    {
                        Success = false,
                        Message = "Token doesn't match"
                    });
                }
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                       db.RefreshTokens.Update(storedToken);
                       await db.SaveChangesAsync();
                       var user = await db.Users.SingleOrDefaultAsync(nd => nd.Id == storedToken.idUser);
                       var token = await CreateToken(user);
                       var newtk = GenerateRefreshToken();
                       SetRefreshToken(token);
                return Ok(new TrangThaiViewModel
                {
                    Success = true,
                    Message = "Gia hạn thành công Token",
                    Data = token

                });
               
            }
            catch (Exception ex)
            {
                return BadRequest(new TrangThaiViewModel
                {
                    Success = false,
                    Message = "Lỗi"
                });
            }
        }


     
        private async Task<TokenViewModel> CreateToken(User user)
        {
            var check = db.Roles.FirstOrDefault(x => x.Id == user.maQuyen);
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:SecretKey").Value!);
            var tokenDe = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role,check.Name.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim("Id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtHandler.CreateToken(tokenDe);
            var accessToken = jwtHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            var refreshTokenEntity = new RefreshToken
            {
                id = Guid.NewGuid(),
                idJwt = token.Id,
                idUser = user.Id,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                ThoiGianTao = DateTime.Now,
                ThoiGianHetHan = DateTime.Now.AddMinutes(15)
            };
            await db.AddAsync(refreshTokenEntity);
            await db.SaveChangesAsync();

           
            return new TokenViewModel
            {
                Accesstoken = accessToken,
                RefreshToken = refreshToken

            };
        }
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }
        private DateTime ChuyenDoi(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }



    }
}
