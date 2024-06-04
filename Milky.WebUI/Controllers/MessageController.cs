using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.MessageValidations;
using Milky.WebUI.Dtos.MessageDtos;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Milky.WebUI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MessageResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult MessageCreate()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> MessageCreate(MessageCreateDto model)
        {
            CreateMessageDtoValidator validationRules = new CreateMessageDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                model.MessageDate = DateTime.Now;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7171/api/Message", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["icon"] = "success";
                    TempData["title"] = "Mesajınız alındı.";
                    return RedirectToAction("Index", "Contact");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index", "Contact");
        }

        [HttpGet]
        public async Task<IActionResult> MessageUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/Message/MessageGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<MessageResultDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("MessageList", "Message");
        }

        public async Task<IActionResult> MessageDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7171/api/Message?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList", "Message");
            }
            return RedirectToAction("MessageList", "Message");
        }
        
    }
}