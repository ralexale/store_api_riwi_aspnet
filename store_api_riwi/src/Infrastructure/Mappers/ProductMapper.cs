using AutoMapper;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Domain.Entities;

namespace store_api_riwi.src.Infrastructure.Mappers
{
    public class ProductMapper: Profile
    {
        public  ProductMapper()
        {
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
