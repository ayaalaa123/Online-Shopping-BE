using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Online_Shopping_Domain.DTO.ProductDTO;
using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure.Services
{
    public class ProductService :IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment _env;


        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository, IMapper mapper , IHostingEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
        }

        public void AddProduct(AddProductDTO addProductDTO)
        {
            var MappedProduct = _mapper.Map<Product>(addProductDTO);
            if(addProductDTO.Image!=null)
            {
                var fileName = Path.GetFileName(addProductDTO.Image.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                     addProductDTO.Image.CopyTo(fileStream);
                }

                MappedProduct.ImagePath = filePath;

            }

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
