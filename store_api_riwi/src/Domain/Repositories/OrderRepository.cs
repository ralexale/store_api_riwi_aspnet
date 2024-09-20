using Microsoft.EntityFrameworkCore;
using store_api_riwi.src.Domain.Entities;

namespace store_api_riwi.src.Domain.Repositories
{
    public class OrderRepository : IRepository<Order>
    {

        private StoreContext _context;

        public OrderRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Get() => await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Product).ToListAsync();

        public async Task<Order> GetById(int id) => await _context.Orders.FindAsync(id);

        public async Task Create(Order order) => await _context.Orders.AddAsync(order);

        public async Task Save() => await _context.SaveChangesAsync();

        public void Update(Order order)
        {
            _context.Orders.Attach(order);
            _context.Orders.Entry(order).State = EntityState.Modified;
        }
        public void Delete(Order order) => _context.Orders.Remove(order);
    }
}
