using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.SiteSocialMediaValidations;
using Milky.WebUI.Dtos.SiteSocialMediaDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class SiteSocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SiteSocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SiteSocialMediaList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/SiteSocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SiteSocialMediaResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SiteSocialMediaCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SiteSocialMediaCreate(SiteSocialMediaCreateDto model)
        {
            CreateSiteSocialMediaDtoValidator validationRules = new CreateSiteSocialMediaDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7155/api/SiteSocialMedia", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SiteSocialMediaList", "SiteSocialMedia");
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
        public async Task<IActionResult> SiteSocialMediaUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/SiteSocialMedia/SiteSocialMediaGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SiteSocialMediaUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("SiteSocialMediaList", "SiteSocialMedia");
        }

        [HttpPost]
        public async Task<IActionResult> SiteSocialMediaUpdate(SiteSocialMediaUpdateDto model)
        {
            UpdateSiteSocialMediaDtoValidator validationRules = new UpdateSiteSocialMediaDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7155/api/SiteSocialMedia", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SiteSocialMediaList", "SiteSocialMedia");
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

        public async Task<IActionResult> SiteSocialMediaDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7155/api/SiteSocialMedia?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SiteSocialMediaList", "SiteSocialMedia");
            }
            return RedirectToAction("SiteSocialMediaList", "SiteSocialMedia");
        }

        // CLIENT
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }
    }
}