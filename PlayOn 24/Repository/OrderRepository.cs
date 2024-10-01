using Microsoft.EntityFrameworkCore;
using PlayOn_24.Context;
using PlayOn_24.Models;

namespace PlayOn_24.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);
			await _context.SaveChangesAsync();
			return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders
                            .Include(o => o.Customer)
                            .Include(o => o.Product)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByCustomer(int id)
        {
             return await _context.Orders
                            .Where(o => o.Customer.Id == id)
                            .Include(o => o.Customer)
                            .Include(o => o.Product)
                            .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            try
			{
				return await _context.Orders
                                .Include(o => o.Customer)
                                .Include(o => o.Product)
                                .SingleAsync(o => o.Id == id);
			}
			catch (Exception)
			{
				return null;
			}
        }
    }
}
