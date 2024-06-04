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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.GetListAll();
            return Ok(values);
        }

        [HttpGet("TestimonialGet")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult TestimonialCreate(Testimonial testimonial)
        {
            _testimonialService.Insert(testimonial);
            return Ok();
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(Testimonial testimonial)
        {
            _testimonialService.Update(testimonial);
            return Ok();
        }

        [HttpDelete]
        public IActionResult TestimonialDelete(int id)
        {
            _testimonialService.Delete(id);
            return Ok();
        }

    }
}