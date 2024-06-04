using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.SocialMediaValidations;
using Milky.WebUI.Dtos.SocialMediaDtos;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Milky.WebUI.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SocialMediaList(int id)
        {
            ViewBag.teamId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/SocialMedia/SocialMediaListByTeamId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SocialMediaResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SocialMediaCreate(int id)
        {
            var model = new SocialMediaCreateDto()
            {
                TeamId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SocialMediaCreate(SocialMediaCreateDto model)
        {
            CreateSocialMediaDtoValidator validationRules = new CreateSocialMediaDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7171/api/SocialMedia", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SocialMediaList", "SocialMedia", new { id = model.TeamId});
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
        public async Task<IActionResult> SocialMediaUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/SocialMedia/SocialMediaGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SocialMediaUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("SocialMediaList", "SocialMedia", new { id = id});
        }

        [HttpPost]
        public async Task<IActionResult> SocialMediaUpdate(SocialMediaUpdateDto model)
        {
            UpdateSocialMediaDtoValidator validationRules = new UpdateSocialMediaDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7171/api/SocialMedia", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SocialMediaList", "SocialMedia", new { id = model.TeamId});
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

        public async Task<IActionResult> SocialMediaDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7171/api/SocialMedia?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList", "SocialMedia");
            }
            return RedirectToAction("SocialMediaList", "SocialMedia");
        }

    }
}