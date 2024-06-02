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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult AddressList()
        {
            var values = _addressService.GetListAll();
            return Ok(values);
        }

        [HttpGet("AddressGet")]
        public IActionResult AddressGet(int id)
        {
            var value = _addressService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddressCreate(Address address)
        {
            _addressService.Insert(address);
            return Ok();
        }

        [HttpPut]
        public IActionResult AddressUpdate(Address address)
        {
            _addressService.Update(address);
            return Ok();
        }

        [HttpDelete]
        public IActionResult AddressDelete(int id)
        {
            _addressService.Delete(id);
            return Ok();
        }

    }
}