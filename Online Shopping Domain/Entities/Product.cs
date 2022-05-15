using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.Entities
{
   public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int  AvailableQuantity { get; set; }

    }
}
