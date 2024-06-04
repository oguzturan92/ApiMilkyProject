using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteSocialMediaController : ControllerBase
    {
        private readonly ISiteSocialMediaService _siteSocialMediaService;

        public SiteSocialMediaController(ISiteSocialMediaService siteSocialMediaService)
        {
            _siteSocialMediaService = siteSocialMediaService;
        }

        [HttpGet]
        public IActionResult SiteSocialMediaList()
        {
            var values = _siteSocialMediaService.GetListAll();
            return Ok(values);
        }

        [HttpGet("SiteSocialMediaGet")]
        public IActionResult SiteSocialMediaGet(int id)
        {
            var value = _siteSocialMediaService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SiteSocialMediaCreate(SiteSocialMedia siteSocialMedia)
        {
            _siteSocialMediaService.Insert(siteSocialMedia);
            return Ok();
        }

        [HttpPut]
        public IActionResult SiteSocialMediaUpdate(SiteSocialMedia siteSocialMedia)
        {
            _siteSocialMediaService.Update(siteSocialMedia);
            return Ok();
        }

        [HttpDelete]
        public IActionResult SiteSocialMediaDelete(int id)
        {
            _siteSocialMediaService.Delete(id);
            return Ok();
        }

    }
}