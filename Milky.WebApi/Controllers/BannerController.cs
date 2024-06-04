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
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        public IActionResult BannerList()
        {
            var values = _bannerService.GetListAll();
            return Ok(values);
        }

        [HttpGet("BannerGet")]
        public IActionResult BannerGet(int id)
        {
            var value = _bannerService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult BannerCreate(Banner banner)
        {
            _bannerService.Insert(banner);
            return Ok();
        }

        [HttpPut]
        public IActionResult BannerUpdate(Banner banner)
        {
            _bannerService.Update(banner);
            return Ok();
        }

        [HttpDelete]
        public IActionResult BannerDelete(int id)
        {
            _bannerService.Delete(id);
            return Ok();
        }

    }
}