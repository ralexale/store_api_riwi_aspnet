using Microsoft.EntityFrameworkCore;
using store_api_riwi.src.Domain.Entities;

namespace store_api_riwi.src.Domain.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private StoreContext _context;

        public UserRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Get() => await _context.Users.ToListAsync();

        public async Task<User> GetById(int id) => await _context.Users.FindAsync(id);

        public async Task Create(User user) => await _context.Users.AddAsync(user);

        public async Task Save() => await _context.SaveChangesAsync();

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Users.Entry(user).State = EntityState.Modified;
        }
        public void Delete(User user) => _context.Users.Remove(user);
    }
}
