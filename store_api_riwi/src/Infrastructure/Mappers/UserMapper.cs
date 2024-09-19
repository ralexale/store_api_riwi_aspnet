﻿using AutoMapper;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Domain.Entities;

namespace store_api_riwi.src.Infrastructure.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {

            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();

        }
    }
}
