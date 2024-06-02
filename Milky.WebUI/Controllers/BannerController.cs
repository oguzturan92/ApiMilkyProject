using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.BannerValidations;
using Milky.WebUI.Dtos.BannerDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BannerList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Banner");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BannerResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult BannerCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BannerCreate(BannerCreateDto model)
        {
            CreateBannerDtoValidator validationRules = new CreateBannerDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7155/api/Banner", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("BannerList", "Banner");
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
        public async Task<IActionResult> BannerUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Banner/BannerGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BannerUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("BannerList", "Banner");
        }

        [HttpPost]
        public async Task<IActionResult> BannerUpdate(BannerUpdateDto model)
        {
            UpdateBannerDtoValidator validationRules = new UpdateBannerDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7155/api/Banner", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("BannerList", "Banner");
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

        public async Task<IActionResult> BannerDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7155/api/Banner?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BannerList", "Banner");
            }
            return RedirectToAction("BannerList", "Banner");
        }

        // CLIENT
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }
    }
}