using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.Dto.AppUserDtos;
using Milky.Entity.Concrete;

namespace Milky.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("UserRegister")]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            if(ModelState.IsValid)
            {
                if (userRegisterDto.Password == userRegisterDto.RePassword)
                {
                    var user = new AppUser()
                    {
                        UserAdi = userRegisterDto.UserAdi,
                        UserSoyadi = userRegisterDto.UserSoyadi,
                        UserRegisterDate = DateTime.Now,
                        Email = userRegisterDto.Email,
                        UserName = userRegisterDto.UserName,
                        EmailConfirmed = true
                    };

                    var createUser = await _userManager.CreateAsync(user, userRegisterDto.Password);
                    if (createUser.Succeeded)
                    {
                        return Ok("Kullanıcı başarıyla oluşturuldu.");
                    } else
                    {
                        foreach (var item in createUser.Errors)
                        {
                            return BadRequest(item.Description);
                        }
                    }
                }
            }
            return Ok();
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            var userLogin = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if(userLogin.Succeeded)
            {
                return Ok("Giriş başarılı");
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpGet("UserLogout")]
        public async Task<IActionResult> UserLogout(int id)
        {
            await _signInManager.SignOutAsync();
            return Ok("Çıkış yapıldı");
        }
    }
}