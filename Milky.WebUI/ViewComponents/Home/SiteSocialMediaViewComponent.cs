using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.SiteSocialMediaDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents.Home
{
    public class SiteSocialMediaViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SiteSocialMediaViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // CLIENT --------------------------------------------------------------------------
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7171/api/SiteSocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SiteSocialMediaResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}