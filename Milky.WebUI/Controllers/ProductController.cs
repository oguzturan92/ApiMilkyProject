using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.ProductValidations;
using Milky.WebUI.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductCreateDto model)
        {
            CreateProductDtoValidator validationRules = new CreateProductDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7155/api/Product", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductList", "Product");
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
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Product/ProductGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductUpdateDto model)
        {
            UpdateProductDtoValidator validationRules = new UpdateProductDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7155/api/Product", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductList", "Product");
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

        public async Task<IActionResult> ProductDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7155/api/Product?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList", "Product");
            }
            return RedirectToAction("ProductList", "Product");
        }

        // CLIENT
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }
    }
}