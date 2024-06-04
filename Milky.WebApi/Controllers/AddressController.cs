using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Milky.Dto.AddressDtos;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
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
        public IActionResult AddressCreate(AddressCreateDto addressCreateDto)
        {
            if (ModelState.IsValid)
            {
                var values = _mapper.Map<Address>(addressCreateDto);
                _addressService.Insert(values);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult AddressUpdate(AddressUpdateDto addressUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var values = _mapper.Map<Address>(addressUpdateDto);
                _addressService.Update(values);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult AddressDelete(int id)
        {
            _addressService.Delete(id);
            return Ok();
        }

    }
}