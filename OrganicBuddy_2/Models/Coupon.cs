using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OrganicBuddy_2.Models
{
	public class Coupon
	{
		public int CouponId { get; set; }

		[Required]
		[MaxLength(255)] // Assuming maximum length for name
		public string Name { get; set; }

		[Required]
		public DateTime Expiry { get; set; }

		[Required]
		public double Discount { get; set; }
	}
}
