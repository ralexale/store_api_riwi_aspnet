using AutoMapper;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Domain.Entities;

namespace store_api_riwi.src.Infrastructure.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderRequest, Order>();


            CreateMap<Order, OrderResponse>()
                   .ForMember(dto => dto.Products, m => m.MapFrom(order => order.Product))
                   .ForMember(dto => dto.Users, m => m.MapFrom(order => order.User));
        }
    }
}
