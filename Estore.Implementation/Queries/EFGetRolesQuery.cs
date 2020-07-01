using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.Application.Searches;
using Estore.DataAccess;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estore.Implementation.Extensions;
using AutoMapper;

namespace Estore.Implementation.Queries
{
    public class EFGetRolesQuery : IGetRolesQuery
    {
        private readonly EstoreContext context;
        private readonly IMapper _mapper;


        public EFGetRolesQuery(EstoreContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Searching roles";

        public IEnumerable<RoleGetDto> Execute(RoleSearch search)
        {
            var query = context.Roles.AsQueryable();
            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            //var skipCount = search.PerPage * (search.Page - 1);
            //var response = new PageResponse<RoleDto>
            //{
            //    CurrentPage = search.Page,
            //    ItemsPerPage = search.PerPage,
            //    TotalCount = query.Count(),
            //    Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new RoleDto
            //    {
            //        Id = x.Id,
            //        Name = x.Name
            //    }).ToList()
            //};
            //return response;
            return _mapper.Map<IEnumerable<RoleGetDto>>(query);
        
            //return query.Paged(search, x => new RoleDto
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //});
        }
    }
}
