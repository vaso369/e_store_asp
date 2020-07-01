using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Application.Exceptions;
using Estore.Application.Queries;
using Estore.DataAccess;
using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Queries
{
    public class EFGetOneProductQuery : IGetOneProductQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;

        public EFGetOneProductQuery(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Getting one product";

        public ProductDtoSearch Execute(int search)
        {
            var query = _context.Products.AsQueryable();
            query = query.Include(p => p.Pictures).Include(pr => pr.Prices).Where(p => p.Id == search);
            if(query.Count() == 0)
            {
                throw new EntityNotFoundException(search, typeof(Product));
            }
            var product = query.Select(x => new ProductDtoSearch
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock,
                ImagePath = x.ImagePath,
                Pictures = x.Pictures.Where(pic => x.Id == pic.ProductId).Select(p => new ImageDto
                {
                    Id = p.Id,
                    Path = p.ImagePath
                }),
                CategoryId = x.CategoryId,
                Prices =x.Prices.Where(p => p.ProductId == x.Id).Select(p => new PriceDtoSearch
                {
                    Id = p.Id,
                    Price = p.Price,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt
                }).OrderByDescending(date => date.CreatedAt).Take(2)
            }).First();
            //  return _mapper.Map<ProductDtoSearch>(query);
            return product;


        }
    }
}
