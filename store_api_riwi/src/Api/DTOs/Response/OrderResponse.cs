namespace store_api_riwi.src.Api.DTOs.Response
{
    public class OrderResponse
    {
        public int Id {  get; set; }

        public ProductResponse Product { get; set; }
        public UserResponse User { get; set; }

    }
}
