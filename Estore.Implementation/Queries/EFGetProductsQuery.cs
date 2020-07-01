using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.Application.Searches;
using Estore.DataAccess;
using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Estore.Implementation.Extensions;
using AutoMapper;

namespace Estore.Implementation.Queries
{
    public class EFGetProductsQuery : IGetProductsQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;

        public EFGetProductsQuery(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Getting products";

        public PageResponse<ProductDtoSearch> Execute(ProductSearch search)
        {

            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()) || x.Description.ToLower().Contains(search.Name.ToLower()));
            }
            if (search.CategoryId != 0)
            {
                if (_context.Categories.Any(c => c.Id == search.CategoryId))
                {
                    query = query.Where(p => p.CategoryId == search.CategoryId);
                }
                else
                {
                    query = query.Take(0);
                }
            }
            if (search.Stock)
            {
                query = query.Where(p => p.Stock > 0);
            }

            //var pricesTable = _context.PriceHistory;
            //var picturesTable = _context.Pictures;
           query = query.Include(pr => pr.Prices);
            //   var prods = query.AsQueryable().Join(picturesTable, products => products.Id, pictures => pictures.ProductId, (products, pictures) => new { products, pictures }).Join(pricesTable, prod => prod.products.Id, price => price.ProductId, (prod, price) => new { prod, price });
            //  if (search.PriceFrom != 0 || search.PriceTo != 0)
            //    {
            //if (search.PriceFrom != 0 && search.PriceTo == 0)
            //    prods = prods.Include(p=>p.Prices).Where(p => p. >= search.PriceFrom);
            //if (search.PriceFrom == 0 && search.PriceTo != 0)
            //    prods = prods.Where(p => p.price.Price >= search.PriceFrom);
            //if (search.PriceFrom != 0 && search.PriceTo != 0)
            //    prods = prods.Where(p => p.price.Price >= search.PriceFrom && p.price.Price <= search.PriceTo);

            //   }

            //var query = prods.Select(x => new ProductDtoSearch
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Stock = x.Stock,
            //    ImagePathPrimary = x.ImagePath,
            //    Images = x.Pictures.Where(pic => x.Id == pic.ProductId).Select(p => new ImageDto
            //    {
            //        Id = p.Id,
            //        Path = p.ImagePath
            //    }),
            //    CategoryId = x.CategoryId,
            //    Prices = x.Prices.Where(p => p.ProductId == x.Id).Select(p => new PriceDtoSearch
            //    {
            //        Id = p.Id,
            //        Price = p.Price,
            //        ProductId = p.ProductId,
            //        CreatedAt = p.CreatedAt
            //    }).OrderByDescending(date => date.CreatedAt).Take(2)
            //});


            //var skipCount = search.PerPage * (search.Page - 1);
            //var response = new PageResponse<ProductDtoSearch>
            //{
            //    CurrentPage = search.Page,
            //    ItemsPerPage = search.PerPage,
            //    TotalCount = query.Count(),
            //    Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ProductDtoSearch
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        Description = x.Description,
            //        Stock = x.Stock,
            //        ImagePath = x.ImagePath,
            //        CategoryId = x.CategoryId,
            //        Prices = x.Prices.Where(p => p.ProductId == x.Id).Select(p => new PriceDtoSearch
            //        {
            //            Id = p.Id,
            //            Price = p.Price,
            //            ProductId = p.ProductId,
            //            CreatedAt = p.CreatedAt
            //        }).OrderByDescending(date => date.CreatedAt).Take(2)
            //    }).ToList()
            //};
            //return response;

            return query.Paged<ProductDtoSearch, Product>(search,_mapper );

        }
    }
}
