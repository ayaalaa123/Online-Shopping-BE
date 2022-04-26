using AutoMapper;
using Online_Shopping_Domain.DTO.ProductDTO;
using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Online_Shopping_Infrastructure.Services
{
    public class ProductService :IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddProduct(AddProductDTO addProductDTO)
        {
            var MappedProduct = _mapper.Map<Product>(addProductDTO);
            _productRepository.Add(MappedProduct);
            _unitOfWork.Commit();

        }

        public void DeleteProduct(Guid Id)
        {
            var ProductInDB = _productRepository.Get(a => a.Id == Id).FirstOrDefault();
            _productRepository.Delete(ProductInDB);
            _unitOfWork.Commit();
        }

        public List<GetProductDTO> GetAllProducts()
        {
            var ProductsInDB = _productRepository.GetAll().ToList();
            var MappedProducts= _mapper.Map<List<Product>, List<GetProductDTO>>(ProductsInDB);
            return MappedProducts;
        }

        public GetProductDTO GetProductById(Guid Id)
        {
            var ProductInDB = _productRepository.Get(a => a.Id == Id).FirstOrDefault();
            var MappedProduct= _mapper.Map<GetProductDTO>(ProductInDB);
            return MappedProduct;
        }

        public void UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var MappedProduct = _mapper.Map<Product>(updateProductDTO);
            _productRepository.Update(MappedProduct);
            _unitOfWork.Commit();
          
        }
    }
}
