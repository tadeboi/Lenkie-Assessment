using System.ComponentModel.DataAnnotations;

namespace Lenkie_Assessment.Models
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
