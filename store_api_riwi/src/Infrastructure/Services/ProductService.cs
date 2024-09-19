using AutoMapper;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Domain.Entities;
using store_api_riwi.src.Domain;
using store_api_riwi.src.Domain.Repositories;
using store_api_riwi.src.Infrastructure.AbstractServices;

namespace store_api_riwi.src.Infrastructure.Services
{
    public class ProductService: ICommonService<ProductResponse,ProductRequest>
    {


        private StoreContext _context;
        private IRepository<Product> _repository;
        private IMapper _mapper;

        public ProductService(StoreContext context, IRepository<Product> productRepository, IMapper mapper)
        {
            _context = context;
            _repository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponse>> Get()
        {
            var products = await _repository.Get();

            return products.Select(_mapper.Map<ProductResponse>);
        }

        public async Task<ProductResponse?> GetById(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> Create(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);

            await _repository.Create(product);
            await _repository.Save();

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse?> Delete(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null) return null;

            var productCopy = _mapper.Map<ProductResponse>(product);

            _repository.Delete(product);
            await _repository.Save();

            return productCopy;
        }


        public async Task<ProductResponse?> Update(int id, ProductRequest request)
        {
            var product = await _repository.GetById(id);

            if (product == null) return null;

            product = _mapper.Map(request, product);

            _repository.Update(product);
            await _repository.Save();

            return _mapper.Map<ProductResponse>(product);
        }
    }
}
