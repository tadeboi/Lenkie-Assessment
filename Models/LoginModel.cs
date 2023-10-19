using System.ComponentModel.DataAnnotations;

namespace Lenkie_Assessment.Models
{
    public class LoginModel
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
