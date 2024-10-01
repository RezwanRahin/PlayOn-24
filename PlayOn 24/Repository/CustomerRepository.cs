using Microsoft.EntityFrameworkCore;
using PlayOn_24.Context;
using PlayOn_24.Models;

namespace PlayOn_24.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
		{
            _context = context;
        }

        public async Task<Customer> Add(Customer customer)
        {
            _context.Customers.Add(customer);
			await _context.SaveChangesAsync();
			return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            try
			{
				return await _context.Customers.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
			}
        }
    }
}
