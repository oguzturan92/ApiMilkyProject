using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Milky.Dto.AboutDtos;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
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
        public IActionResult AboutCreate(AboutCreateDto aboutCreateDto)
        {
            if (ModelState.IsValid)
            {
                var values = _mapper.Map<About>(aboutCreateDto);
                _aboutService.Insert(values);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult AboutUpdate(AboutUpdateDto aboutUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var values = _mapper.Map<About>(aboutUpdateDto);
                _aboutService.Update(values);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult AboutDelete(int id)
        {
            _aboutService.Delete(id);
            return Ok();
        }

    }
}