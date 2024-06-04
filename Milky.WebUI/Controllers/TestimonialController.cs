using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.TestimonialDtos;
using Milky.WebUI.Validation.TestimonialValidation;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult TestimonialCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(TestimonialCreateDto model)
        {
            CreateTestimonialDtoValidator validationRules = new CreateTestimonialDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7171/api/Testimonial", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("TestimonialList", "Testimonial");
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
        public async Task<IActionResult> TestimonialUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/Testimonial/TestimonialGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("TestimonialList", "Testimonial");
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialUpdate(TestimonialUpdateDto model)
        {
            UpdateTestimonialDtoValidator validationRules = new UpdateTestimonialDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7171/api/Testimonial", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("TestimonialList", "Testimonial");
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

        public async Task<IActionResult> TestimonialDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7171/api/Testimonial?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList", "Testimonial");
            }
            return RedirectToAction("TestimonialList", "Testimonial");
        }

    }
}