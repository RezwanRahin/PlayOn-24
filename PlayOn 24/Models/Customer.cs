using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PlayOn_24.Models
{
	[Index(nameof(Email), IsUnique = true)]
	public class Customer
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
