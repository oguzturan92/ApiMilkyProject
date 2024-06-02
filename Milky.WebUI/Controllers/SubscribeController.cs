using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.SubscribeValidations;
using Milky.WebUI.Dtos.SubscribeDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SubscribeList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseSubscribe = await client.GetAsync("https://localhost:7155/api/Subscribe");
            if (responseSubscribe.IsSuccessStatusCode)
            {
                var jsonData = await responseSubscribe.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SubscribeResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SubscribeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeCreate(SubscribeCreateDto model)
        {
            CreateSubscribeDtoValidator validationRules = new CreateSubscribeDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                model.SubscribeDate = DateTime.Now;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseSubscribe = await client.PostAsync("https://localhost:7155/api/Subscribe", stringContent);
                if (responseSubscribe.IsSuccessStatusCode)
                {
                    TempData["icon"] = "success";
                    TempData["title"] = "Kayıt tamamlandı.";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SubscribeDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseSubscribe = await client.DeleteAsync("https://localhost:7155/api/Subscribe?id=" + id);
            if (responseSubscribe.IsSuccessStatusCode)
            {
                return RedirectToAction("SubscribeList", "Subscribe");
            }
            return RedirectToAction("SubscribeList", "Subscribe");
        }
        
    }
}