using PlayOn_24.Models;

namespace PlayOn_24.Repository
{
	public interface IProductRepository
	{
		Task<Product> Add(Product product);
		Task<Product?> GetProductById(int id);
		Task<IEnumerable<Product>> GetAllProducts();
	}
}
