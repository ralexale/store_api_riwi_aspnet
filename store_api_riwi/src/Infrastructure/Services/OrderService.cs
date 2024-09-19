using AutoMapper;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Domain.Entities;
using store_api_riwi.src.Domain.Repositories;
using store_api_riwi.src.Domain;
using store_api_riwi.src.Infrastructure.AbstractServices;

namespace store_api_riwi.src.Infrastructure.Services
{
    public class OrderService: ICommonService<OrderResponse,OrderRequest>
    {
        private StoreContext _context;
        private IRepository<Order> _repository;
        private IMapper _mapper;

        public OrderService(StoreContext context, IRepository<Order> orderRepository, IMapper mapper)
        {
            _context = context;
            _repository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> Get()
        {
            var orders = await _repository.Get();

            return orders.Select(_mapper.Map<OrderResponse>);
        }

        public async Task<OrderResponse?> GetById(int id)
        {
            var order = await _repository.GetById(id);

            if (order == null)
            {
                return null;
            }
            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse> Create(OrderRequest request)
        {
            var order = _mapper.Map<Order>(request);

            await _repository.Create(order);
            await _repository.Save();

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse?> Delete(int id)
        {
            var order = await _repository.GetById(id);
            if (order == null) return null;

            var orderCopy = _mapper.Map<OrderResponse>(order);

            _repository.Delete(order);
            await _repository.Save();

            return orderCopy;
        }


        public async Task<OrderResponse?> Update(int id, OrderRequest request)
        {
            var order = await _repository.GetById(id);

            if (order == null) return null;

            order = _mapper.Map(request, order);

            _repository.Update(order);
            await _repository.Save();

            return _mapper.Map<OrderResponse>(order);
        }
    }
}
