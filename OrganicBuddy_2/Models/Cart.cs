using Microsoft.AspNetCore.Mvc;

namespace OrganicBuddy_2.Models
{
	public class Cart
	{
		public int CartId { get; set; }

		public virtual ICollection<CartItem> Products { get; set; }

		public double CartTotal { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}

	public class CartItem
	{
		public int CartItemId { get; set; }

		public int ProductId { get; set; }
		public virtual Prod Product { get; set; }

		public int Count { get; set; }

		public double Price { get; set; }
	}

	// You can define your Product and User classes as well if not already defined
	public class Prod
	{
		public int ProductId { get; set; }

		// Add other properties as needed
	}

	
}
