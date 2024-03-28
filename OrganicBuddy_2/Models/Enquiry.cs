using System.ComponentModel.DataAnnotations;

namespace OrganicBuddy_2.Models
{
    public class Enquiry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        public string Comment { get; set; }

        [EnumDataType(typeof(EnquiryStatus))]
        public string Status { get; set; } = EnquiryStatus.Submitted.ToString();
    }
    public enum EnquiryStatus
    {
        Submitted,
        Contacted,
        InProgress,
        Resolved
    }
}
