using Api.Dto.Account;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMessageService _messageService;
        private readonly IDistributedCache _distributedCache;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager,
            IMessageService messageService, IAccountRepository accountRepository, IDistributedCache distributedCache)
        {
            _userManager = userManager;
            _distributedCache = distributedCache;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _messageService = messageService;
            _accountRepository = accountRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Username not found or password incorrect");

            var token = _tokenService.CreateToken(user);
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Path = "/",
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("jwtToken", token, cookieOption);

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                }
            );
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };
                if(!(await _accountRepository.CheckEmail(appUser.Email)))
                {
                    return StatusCode(503, "email is used");
                }

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var token = _tokenService.CreateToken(appUser);
                    var cookieOption = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Path = "/",
                        SameSite = SameSiteMode.None,
                        Expires = DateTime.UtcNow.AddDays(7)
                    };

                    Response.Cookies.Append("jwtToken", token, cookieOption);

                    return Ok(
                        new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,

                        });
                }
                else
                {
                    return StatusCode(501, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(502, ex);
            }
        }

        [HttpDelete("Delete/{Email}")]
        public async Task<IActionResult> Delete(string Email)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            if(User == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(User);
            return Ok();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwtToken", new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.None
            });
            return Ok();
        }

        [HttpGet("GetId")]
        public async Task<IActionResult> GetId()
        {
            var token = Request.Cookies["jwtToken"];
            if (token == null)
            {
                return Unauthorized("Token not found");
            }
            var NameId = _tokenService.DecodeToken(token);
            if(NameId == null)
            {
                return NotFound();
            }
            return Ok(NameId);
        }

        [HttpPost("SendCode/{email}")]
        public async Task<IActionResult> SendCode([FromRoute] string email)
        {
            string code = await _messageService.SendMail(email);
            var cache = new DistributedCacheEntryOptions { 
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };
            await _distributedCache.SetStringAsync($"verification_code_{email}", code, cache);

            return Ok(code);
        }

        [HttpPost("VerifyCode/{email}/{code}")]
        public async Task<IActionResult> VerifyCode([FromRoute] string email,string code)
        {
            var storedCode = await _distributedCache.GetStringAsync($"verification_code_{email}");
            
            if(storedCode == null)
            {
                return BadRequest("Time over");
            }
            if(storedCode != code)
            {
                return BadRequest("Invalid code");
            }

            await _distributedCache.RemoveAsync($"verification_code_{email}");
            return Ok();
            
        }

    }
}
