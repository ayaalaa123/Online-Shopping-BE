using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Interfaces;
using Online_Shopping_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult AddProduct(Product  product)
        {
            _productService.AddProduct(product);
            return Ok();

        }
    }
}
