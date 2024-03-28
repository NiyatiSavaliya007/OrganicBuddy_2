using System.ComponentModel.DataAnnotations;
namespace OrganicBuddy_2.Models
{
    public class Pro
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Variety { get; set; }

        [Required]
        public string Nutrition { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
    public class ProductImage
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
    }

   
}
