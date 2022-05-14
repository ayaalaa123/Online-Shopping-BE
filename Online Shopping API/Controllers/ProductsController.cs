using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Domain.DTO.ProductDTO;
using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Interfaces;
using Online_Shopping_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Online_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpPost]
        public IActionResult AddProduct([FromForm]  AddProductDTO addProductDTO)
        {
            try
            {
               
                _productService.AddProduct(addProductDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var response = _productService.GetAllProducts();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("{Id}")]
        public IActionResult GetProductById(Guid Id)
        {
            try
            {
                var response = _productService.GetProductById(Id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }


        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            try
            {
                 _productService.UpdateProduct(updateProductDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(Guid Id)
        {
            try
            {
                _productService.DeleteProduct(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
