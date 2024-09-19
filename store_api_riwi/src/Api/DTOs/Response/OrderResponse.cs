namespace store_api_riwi.src.Api.DTOs.Response
{
    public class OrderResponse
    {
        public int Id {  get; set; }

        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
        public List<UserResponse> Users { get; set; } = new List<UserResponse>();

    }
}
