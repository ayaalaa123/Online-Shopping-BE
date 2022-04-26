using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.DTO.ProductDTO
{
   public class GetProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Describtion { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
