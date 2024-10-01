using PlayOn_24.Models;

namespace PlayOn_24.Repository
{
	public interface ICustomerRepository
	{
		Task<Customer> Add(Customer customer);
		Task<Customer?> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetAllCustomers();
	}
}
