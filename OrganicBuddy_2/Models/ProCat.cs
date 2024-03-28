using System.ComponentModel.DataAnnotations;

namespace OrganicBuddy_2.Models
{
    public class ProCat
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)] // Adjust max length as needed
        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
