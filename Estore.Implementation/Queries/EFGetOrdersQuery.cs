using AutoMapper;
using Estore.Application;
using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.Application.Searches;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Queries
{
    public class EFGetOrdersQuery : IGetOrdersQuery
    {
        private readonly EstoreContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EFGetOrdersQuery(EstoreContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Getting orders";

        public PageResponse<OrderWithUserDataDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.AsQueryable();
            query = query.Include(o => o.OrderLines).Include(o => o.User);

            if (search.OrderDate != default(DateTime))
            {
                query = query.Where(o => o.CreatedAt.Date == search.OrderDate);
            }

            return query.Paged<OrderWithUserDataDto, Order>(search, _mapper);

        }
    }
}
