using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donations_Api.Entities
{
    /// <summary>
    /// Entity For Transaction Persistance
    /// </summary>
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string pesapalTrackingId { get; set; }
        [Required]
        public string paymentMethod { get; set; }
        [Required]
        public string paymentStatus { get; set; }
        [Required]
        public string reference { get; set; }
        [Required]
        public string BuyerName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
