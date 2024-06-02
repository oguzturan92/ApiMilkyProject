using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.SliderValidation;
using Milky.WebUI.Dtos.SliderDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SliderList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Slider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SliderResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SliderCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SliderCreate(SliderCreateDto model)
        {
            CreateSliderDtoValidator validationRules = new CreateSliderDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7155/api/Slider", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SliderList", "Slider");
                }
                return View();
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
        public async Task<IActionResult> SliderUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Slider/SliderGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SliderUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("SliderList", "Slider");
        }

        [HttpPost]
        public async Task<IActionResult> SliderUpdate(SliderUpdateDto model)
        {
            UpdateSliderDtoValidator validationRules = new UpdateSliderDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7155/api/Slider", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SliderList", "Slider");
                }
                return View();
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

        public async Task<IActionResult> SliderDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7155/api/Slider?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList", "Slider");
            }
            return RedirectToAction("SliderList", "Slider");
        }

    }
}