using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _aboutService;

        public MessageController(IMessageService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _aboutService.GetListAll();
            return Ok(values);
        }

        [HttpGet("MessageGet")]
        public IActionResult MessageGet(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult MessageCreate(Message about)
        {
            _aboutService.Insert(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult MessageDelete(int id)
        {
            _aboutService.Delete(id);
            return Ok();
        }

    }
}