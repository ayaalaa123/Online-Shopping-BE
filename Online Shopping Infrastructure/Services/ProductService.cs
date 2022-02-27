using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Infrastructure.Services
{
    public class ProductService :IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
            _unitOfWork.Commit();

        }
    }
}
