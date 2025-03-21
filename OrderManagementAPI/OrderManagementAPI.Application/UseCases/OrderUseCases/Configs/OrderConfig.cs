using AutoMapper;
using OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.UseCases.OrderUseCases.Configs
{
    public class OrderConfig : Profile
    {
        public OrderConfig()
        {
            CreateMap<Order,GetOrderResponse>();
            CreateMap<CreateOrderRequest, Order>();
        }
    }
}
