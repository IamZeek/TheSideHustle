using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheSideHustle.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember Password")]
        public bool RememberMe { get; set; }
    }
}
