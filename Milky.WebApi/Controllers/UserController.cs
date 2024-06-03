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

        // [HttpPost("UserLogin")]
        // public async Task<IActionResult> UserLogin(CreateLoginDto createLoginDto)
        // {
        //     var user = await _userManager.FindByEmailAsync(createLoginDto.Email);
        //     var loginuser = await _signInManager.PasswordSignInAsync(user.UserName, createLoginDto.Password, false, false);
        //     if(loginuser.Succeeded)
        //     {
        //         return Ok(loginuser);
        //     }
        //     else
        //     {
        //         var result = new LoginErrorViewModel()
        //         {
        //             Error = "Kullanıcı adı veya şifre hatalı!!"
        //         };
        //         return BadRequest(result);
        //     }
        // }

        [HttpGet("UserLogout")]
        public async Task<IActionResult> UserLogout(int id)
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}