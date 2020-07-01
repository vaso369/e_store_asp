using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDtoSearch>().ForMember( dto => dto.Pictures, opt => opt.MapFrom(product => product.Pictures.Select(pp => new ImageDto { 
               Id = pp.Id,
               Path = pp.ImagePath
            }))).ForMember(dto => dto.Prices, opt => opt.MapFrom(product => product.Prices.Select(pp => new PriceDtoSearch
            {
                Id = pp.Id,
                Price = pp.Price,
                CreatedAt = pp.CreatedAt,
                ProductId = pp.ProductId
            }).OrderByDescending(date => date.CreatedAt).Take(2)));
                                                 
            CreateMap<ProductDtoSearch,Product>();
        }
    }
}
