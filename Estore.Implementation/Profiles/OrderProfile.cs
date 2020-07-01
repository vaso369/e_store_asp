using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ForMember(order => order.OrderLines, opt => opt.MapFrom(ol => ol.OrderLines.Select(ol => new OrderLineDto
            {
                Name = ol.Name,
                OrderId = ol.OrderId,
                Price = ol.Price,
                ProductId = ol.ProductId,
                Quantity = ol.Quantity,
                TotalPrice = ol.Quantity * ol.Price
            })));
            CreateMap<Order, OrderWithUserDataDto>().ForMember(order => order.OrderLines, opt => opt.MapFrom(ol => ol.OrderLines.Select(ol => new OrderLineDto
            {
                Name = ol.Name,
                OrderId = ol.OrderId,
                Price = ol.Price,
                ProductId = (int)ol.ProductId,
                Quantity = ol.Quantity,
                TotalPrice = ol.Quantity * ol.Price
            }))).ForMember(order => order.FirstName, opt => opt.MapFrom(o => o.User.FirstName))
            .ForMember(order => order.LastName, opt => opt.MapFrom(o => o.User.LastName))
            .ForMember(order => order.PID, opt => opt.MapFrom(o => o.User.PID));


        }
    }
}
