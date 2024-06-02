using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.TeamDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Home
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TeamViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // CLIENT --------------------------------------------------------------------------
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Team/GetTeamsListAndSocials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TeamSocialMediaResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}