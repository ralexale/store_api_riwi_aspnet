namespace store_api_riwi.src.Infrastructure.AbstractServices
{
    public interface ICommonService<TResponse, TRequest>
    {
        Task<IEnumerable<TResponse>> Get();

        Task<TResponse> GetById(int id);

        Task<TResponse> Create(TRequest request);

        Task<TResponse> Update(int id ,TRequest request);

        Task<TResponse> Delete(int id);
    }
}
