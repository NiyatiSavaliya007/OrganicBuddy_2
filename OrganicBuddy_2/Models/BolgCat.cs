using System.ComponentModel.DataAnnotations;
namespace OrganicBuddy_2.Models
{
    public class BolgCat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)] // Adjust max length as needed
        public string Title { get; set; }
    }
}
