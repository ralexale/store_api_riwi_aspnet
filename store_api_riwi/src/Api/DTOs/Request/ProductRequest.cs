namespace store_api_riwi.src.Api.DTOs.Request
{
    public class ProductRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
    }
}
