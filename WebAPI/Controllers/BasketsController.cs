using Business.Abstract;
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
    public class BasketsController : ControllerBase
    {
        IBasketService _basketSerivce;

        public BasketsController(IBasketService basketSerivce)
        {
            _basketSerivce = basketSerivce;
        }

        
        [HttpPost("add")]
        public IActionResult Add(Basket basket)
        {
            var result = _basketSerivce.Add(basket);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Basket basket)
        {
            var result = _basketSerivce.Delete(basket);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult update(Basket basket)
        {
            var result = _basketSerivce.Update(basket);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            var result = _basketSerivce.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
