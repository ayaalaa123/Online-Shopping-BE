using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.Entities
{
   public class Product :BaseEntity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int  AvailableQuantity { get; set; }

    }
}
