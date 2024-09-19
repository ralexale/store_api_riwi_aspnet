using AutoMapper;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Domain;
using store_api_riwi.src.Domain.Entities;
using store_api_riwi.src.Domain.Repositories;
using store_api_riwi.src.Infrastructure.AbstractServices;

namespace store_api_riwi.src.Infrastructure.Services
{
    public class UserService : ICommonService<UserResponse, UserRequest>
    {
        private StoreContext _context;
        private IRepository<User> _repository;
        private IMapper _mapper;

        public UserService(StoreContext context, IRepository<User> userRepository, IMapper mapper)
        {
            _context = context;
            _repository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> Get()
        {
            var users = await _repository.Get();

            return users.Select(_mapper.Map<UserResponse>);
        }

        public async Task<UserResponse?> GetById(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Create(UserRequest request)
        {
            var user =  _mapper.Map<User>(request);

            await _repository.Create(user);
            await _repository.Save();

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse?> Delete(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null) return null;

            var userCopy = _mapper.Map<UserResponse>(user);

            _repository.Delete(user);
            await _repository.Save();

            return userCopy;
        }


        public async Task<UserResponse?> Update(int id, UserRequest request)
        {
            var user = await _repository.GetById(id);

            if (user == null) return null;

            user = _mapper.Map(request, user);

            _repository.Update(user);
            await _repository.Save();

            return _mapper.Map<UserResponse>(user);
        }
    }
}
