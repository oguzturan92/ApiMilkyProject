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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.GetListAll();
            return Ok(values);
        }

        [HttpGet("AboutGet")]
        public IActionResult AboutGet(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AboutCreate(About about)
        {
            _aboutService.Insert(about);
            return Ok();
        }

        [HttpPut]
        public IActionResult AboutUpdate(About about)
        {
            _aboutService.Update(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult AboutDelete(int id)
        {
            _aboutService.Delete(id);
            return Ok();
        }

    }
}