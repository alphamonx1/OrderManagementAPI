using AutoMapper;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Configs
{
    public class OrderDetailConfig : Profile
    {
        public OrderDetailConfig()
        {
            CreateMap<OrderDetails, GetOrderDetailResponse>();
            CreateMap<CreateOrderDetailRequest, OrderDetails>();
        }

    }
}
