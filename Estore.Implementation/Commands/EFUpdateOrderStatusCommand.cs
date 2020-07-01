using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.Application.Exceptions;
using Estore.DataAccess;
using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFUpdateOrderStatusCommand : IUpdateOrderStatusCommand
    {
        private readonly EstoreContext _context;

        public EFUpdateOrderStatusCommand(EstoreContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Changing order status";

        public void Execute(ChangeOStatusDto request)
        {
            var order = _context.Orders.AsQueryable().Include(o=>o.OrderLines).ThenInclude(order => order.Product).FirstOrDefault(o => o.Id == request.OrderId);
          

            if(order == null)
            {
                throw new EntityNotFoundException(request.OrderId, typeof(Order));
            }

            if(order.OrderStatus == OrderStatus.Delivered)
            {
                throw new ConflictOrderStatusException("Cannot change status of delivered order!");
            }

            if(order.OrderStatus == OrderStatus.OnHold)
            {
                if(request.Status == OrderStatus.Delivered)
                {
                    throw new ConflictOrderStatusException("Order cannot be changed from recieved to delivered directly!");
                }
            }
          
                if(request.Status == OrderStatus.Canceled || request.Status == OrderStatus.Shipped)
                {
                    order.OrderStatus = request.Status;
                    if(request.Status == OrderStatus.Canceled)
                    {
                
                        foreach(var item in order.OrderLines)
                        {
           
                            item.Product.Stock += item.Quantity;
                        }
                    }
                    _context.SaveChanges();
                    
                }
                
            
            
        }
    }
}
