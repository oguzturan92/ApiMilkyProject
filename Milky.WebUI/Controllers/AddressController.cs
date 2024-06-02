using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.AddressValidations;
using Milky.WebUI.Dtos.AddressDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AddressList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Address");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AddressResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddressCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddressCreate(AddressCreateDto model)
        {
            CreateAddressDtoValidator validationRules = new CreateAddressDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7155/api/Address", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("AddressList", "Address");
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
        public async Task<IActionResult> AddressUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Address/AddressGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AddressUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("AddressList", "Address");
        }

        [HttpPost]
        public async Task<IActionResult> AddressUpdate(AddressUpdateDto model)
        {
            UpdateAddressDtoValidator validationRules = new UpdateAddressDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7155/api/Address", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("AddressList", "Address");
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

        public async Task<IActionResult> AddressDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7155/api/Address?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AddressList", "Address");
            }
            return RedirectToAction("AddressList", "Address");
        }

        // CLIENT
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }
    }
}