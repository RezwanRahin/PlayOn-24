using PlayOn_24.Models;

namespace PlayOn_24.Repository
{
	public interface IOrderRepository
	{
		Task<Order> Add(Order order);
		Task<Order?> GetOrderById(int id);
		Task<IEnumerable<Order>> GetAllOrders();
		Task<IEnumerable<Order>> GetAllOrdersByCustomer(int id);
	}
}
