using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.DTO.ProductDTO
{
   public class AddProductDTO
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Describtion { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
