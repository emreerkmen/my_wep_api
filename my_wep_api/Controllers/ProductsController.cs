using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_wep_api.DataAccess;
using my_wep_api.Entities;

namespace my_wep_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var products = _productDal.Get(p => p.ProductId == productId);

                if (products == null)
                {
                    return NotFound($"{productId} id'li product bulunamamıştır.");

                }

                return Ok(products);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            try
            {
                _productDal.Add(product);

                return Ok($"Yeni product eklenmiştir. ProductId: {product.ProductId}" );
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            try
            {
                _productDal.Update(product);

                return Ok($"{product.ProductId} 'li product güncellenmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId=productId});

                return Ok($"{productId} 'li product silinmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpGet("GetProductDetails")]
        public IActionResult GetProductDetails()
        {
            try
            {
                var result = _productDal.GetProductsWithDetails();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}