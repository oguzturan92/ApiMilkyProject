using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Validation.TeamValidations;
using Milky.WebUI.Dtos.TeamDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Team");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TeamResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult TeamCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TeamCreate(TeamCreateDto model)
        {
            CreateTeamDtoValidator validationRules = new CreateTeamDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7155/api/Team", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("TeamList", "Team");
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
        public async Task<IActionResult> TeamUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Team/TeamGet?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TeamUpdateDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("TeamList", "Team");
        }

        [HttpPost]
        public async Task<IActionResult> TeamUpdate(TeamUpdateDto model)
        {
            UpdateTeamDtoValidator validationRules = new UpdateTeamDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7155/api/Team", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("TeamList", "Team");
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

        public async Task<IActionResult> TeamDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7155/api/Team?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList", "Team");
            }
            return RedirectToAction("TeamList", "Team");
        }

        // CLIENT
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }
    }
}