namespace store_api_riwi.src.Api.DTOs.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
    }
}
