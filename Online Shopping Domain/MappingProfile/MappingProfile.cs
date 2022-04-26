using AutoMapper;
using Online_Shopping_Domain.DTO;
using Online_Shopping_Domain.DTO.ProductDTO;
using Online_Shopping_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.MappingProfile
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects      
            CreateMap<AddUserDTO, User>();
            CreateMap<AddProductDTO, Product>();

            CreateMap<Product, GetProductDTO>();

            CreateMap<UpdateProductDTO, Product>();


        }

    }
}
