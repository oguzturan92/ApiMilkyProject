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
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.GetListAll();
            return Ok(values);
        }

        [HttpGet("SocialMediaGet")]
        public IActionResult SocialMediaGet(int id)
        {
            var value = _socialMediaService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SocialMediaCreate(SocialMedia socialMedia)
        {
            _socialMediaService.Insert(socialMedia);
            return Ok();
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(SocialMedia socialMedia)
        {
            _socialMediaService.Update(socialMedia);
            return Ok();
        }

        [HttpDelete]
        public IActionResult SocialMediaDelete(int id)
        {
            _socialMediaService.Delete(id);
            return Ok();
        }

        [HttpGet("SocialMediaListByTeamId/{id}")]
        public IActionResult SocialMediaListByTeamId(int id)
        {
            var values = _socialMediaService.SocialMediaListByTeamId(id);
            return Ok(values);
        }

    }
}