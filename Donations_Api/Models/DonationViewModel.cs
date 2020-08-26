using System.ComponentModel.DataAnnotations;

namespace Donations_Api.Models
{
    public class DonationViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required]
        [Display(Name = "Donation Amount")]
        public decimal Amount { get; set; }
    }
}
