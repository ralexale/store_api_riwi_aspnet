﻿namespace store_api_riwi.src.Api.DTOs.Response
{
    public class UserResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Lastname { get; set; }
    }
}
