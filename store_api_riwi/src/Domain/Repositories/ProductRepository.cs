using Microsoft.EntityFrameworkCore;
using store_api_riwi.src.Domain.Entities;

namespace store_api_riwi.src.Domain.Repositories
{
    public class ProductRepository: IRepository<Product>
    {

        private StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Get() => await _context.Products.ToListAsync();

        public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);

        public async Task Create(Product product) => await _context.Products.AddAsync(product);

        public async Task Save() => await _context.SaveChangesAsync();

        public void Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Products.Entry(product).State = EntityState.Modified;
        }
        public void Delete(Product product) => _context.Products.Remove(product);

       
    }
}
