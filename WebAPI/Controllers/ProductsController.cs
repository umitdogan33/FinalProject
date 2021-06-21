using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class ProductsController : ControllerBase
    {
        IProductService  _productservice;

        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            var result= _productservice.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]

        public IActionResult BetById(int Id)
        {
            var result = _productservice.GetById(Id);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //HttpAdd methodu kullanılabilir fakat bu daha fonksyonel olduğu için HtppPost kullanıyoruz
        [HttpPost("Add")]
        public IActionResult Add(Product product) 
        {
          var result=  _productservice.Add(product);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetByCategory")]

        public IActionResult GetByCategoryId(int Categoryıd)
        {
            var result = _productservice.GetAllByCategoryId(Categoryıd);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAllDetails")]
        public IActionResult GetAllDetails()
        {
            var result = _productservice.GetProductDetails(); 
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
