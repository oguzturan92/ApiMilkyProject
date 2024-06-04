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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.GetListAll();
            return Ok(values);
        }

        [HttpGet("ServiceGet")]
        public IActionResult ServiceGet(int id)
        {
            var value = _serviceService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult ServiceCreate(Service service)
        {
            _serviceService.Insert(service);
            return Ok();
        }

        [HttpPut]
        public IActionResult ServiceUpdate(Service service)
        {
            _serviceService.Update(service);
            return Ok();
        }

        [HttpDelete]
        public IActionResult ServiceDelete(int id)
        {
            _serviceService.Delete(id);
            return Ok();
        }

    }
}