using Microsoft.EntityFrameworkCore;
using PlayOn_24.Context;
using PlayOn_24.Models;

namespace PlayOn_24.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            try
			{
				return await _context.Products.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
			}
        }
    }
}
