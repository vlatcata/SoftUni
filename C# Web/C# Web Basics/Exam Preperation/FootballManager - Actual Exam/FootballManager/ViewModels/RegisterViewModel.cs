using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between {2} and {1} characters long")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between {2} and {1} characters long")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
