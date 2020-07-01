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

           
             query = query.Include(pr => pr.Prices);

            return query.Paged<ProductDtoSearch, Product>(search,_mapper );

        }
    }
}
