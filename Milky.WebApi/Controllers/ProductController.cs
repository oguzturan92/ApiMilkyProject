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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.GetListAll();
            return Ok(values);
        }

        [HttpGet("ProductGet")]
        public IActionResult ProductGet(int id)
        {
            var value = _productService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult ProductCreate(Product product)
        {
            _productService.Insert(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult ProductUpdate(Product product)
        {
            _productService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public IActionResult ProductDelete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

    }
}