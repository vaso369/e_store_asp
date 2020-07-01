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
    public class EFGetOneOrderQuery : IGetOneOrderQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;

        public EFGetOneOrderQuery(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Getting one order";

        public OrderWithUserDataDto Execute(int search)
        {
            var orders = _context.Orders.Include(o => o.OrderLines).Include(o => o.User).AsQueryable().IgnoreQueryFilters();

            var order = orders.Where(o => o.Id == search).FirstOrDefault();
            if(order == null)
            {
                throw new EntityNotFoundException(search, typeof(Order));
            }
            return _mapper.Map<OrderWithUserDataDto>(order);
        }
    }
}
