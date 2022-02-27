using Online_Shopping_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Infrastructure.Interfaces
{
    public interface IProductService
    {
        public void AddProduct(Product product);
    }
}
