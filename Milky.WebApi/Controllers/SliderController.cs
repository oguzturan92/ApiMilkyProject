using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.Business.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _sliderService.GetListAll();
            return Ok(values);
        }

        [HttpGet("SliderGet")]
        public IActionResult SliderGet(int id)
        {
            var value = _sliderService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SliderCreate(Slider slider)
        {
            _sliderService.Insert(slider);
            return Ok();
        }

        [HttpPut]
        public IActionResult SliderUpdate(Slider slider)
        {
            _sliderService.Update(slider);
            return Ok();
        }

        [HttpDelete]
        public IActionResult SliderDelete(int id)
        {
            _sliderService.Delete(id);
            return Ok();
        }

    }
}