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
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _aboutService;

        public SubscribeController(ISubscribeService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _aboutService.GetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult SubscribeCreate(Subscribe about)
        {
            _aboutService.Insert(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult SubscribeDelete(int id)
        {
            _aboutService.Delete(id);
            return Ok();
        }

    }
}