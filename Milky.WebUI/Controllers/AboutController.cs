using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.AboutValidations;
using Milky.WebUI.Dtos.AboutDtos;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Milky.WebUI.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AboutResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AboutCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AboutCreate(AboutCreateDto model)
        {
            CreateAboutDtoValidator validationRules = new CreateAboutDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7171/api/About", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("AboutList", "About");
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
        public async Task<IActionResult> AboutUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/About/AboutGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AboutUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("AboutList", "About");
        }

        [HttpPost]
        public async Task<IActionResult> AboutUpdate(AboutUpdateDto model)
        {
            UpdateAboutDtoValidator validationRules = new UpdateAboutDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7171/api/About", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("AboutList", "About");
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

        public async Task<IActionResult> AboutDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7171/api/About?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList", "About");
            }
            return RedirectToAction("AboutList", "About");
        }

        // CLIENT
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }
    }
}