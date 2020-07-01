using AutoMapper;
using Estore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PageResponse<TDto> Paged<TDto, TEntity>(this IQueryable<TEntity> query, PageSearch search, IMapper mapper) where TDto : class
        {

            var skipCount = search.PerPage * (search.Page - 1);
            var broj = query.Count();
            var skipped = query.Skip(skipCount).Take(search.PerPage);
            var response = new PageResponse<TDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = mapper.Map<IEnumerable<TDto>>(skipped)
            };
            return response;
        }
//           return query.Paged(search, x => new ProductDtoSearch
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Description = x.Description,
//                Stock = x.Stock,
//                ImagePathPrimary = x.ImagePath,
//                Images = x.Pictures.Where(pic => x.Id == pic.ProductId).Select(p => new ImageDto
//                {
//                    Id = p.Id,
//                    Path = p.ImagePath
//    }),
//                CategoryId = x.CategoryId,
//                Prices = x.Prices.Where(p => p.ProductId == x.Id).Select(p => new PriceDtoSearch
//                {
//                    Id = p.Id,
//                    Price = p.Price,
//                    ProductId = p.ProductId,
//                    CreatedAt = p.CreatedAt
//}).OrderByDescending(date => date.CreatedAt).Take(2)
//            });
    }
}
