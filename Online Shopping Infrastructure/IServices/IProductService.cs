using Online_Shopping_Domain.DTO.ProductDTO;
using Online_Shopping_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Infrastructure.Interfaces
{
    public interface IProductService
    {
        public void AddProduct(AddProductDTO addProductDTO);

        public List<GetProductDTO> GetAllProducts();

        public GetProductDTO GetProductById(Guid Id);

        public void UpdateProduct(UpdateProductDTO updateProductDTO);

        public void DeleteProduct(Guid Id);


    }
}
