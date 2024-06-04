using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.Entity.Concrete;
using Milky.WebUI.Dtos.UserDtos;
using Milky.WebUI.Validation.UserValidations;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _httpClientFactory = httpClientFactory;            
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto model)
        {
            UserRegisterDtoValidator validationRules = new UserRegisterDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7171/api/User/UserRegister", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("UserLogin", "User");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto model)
        {
            UserLoginDtoValidator validationRules = new UserLoginDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7171/api/User/UserLogin", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> UserLogout()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/User/UserLogout");
            if (responseMessage.IsSuccessStatusCode)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("UserLogin", "User");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}