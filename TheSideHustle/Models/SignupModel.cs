using System.ComponentModel.DataAnnotations;

namespace TheSideHustle.Models
{
    public class SignupModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage = "Password and confirmation should be the same.")]
        public string ConfirmPassword { get; set; }
    }
}
