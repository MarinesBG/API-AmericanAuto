using System.ComponentModel.DataAnnotations;

namespace AmericanAuto.Models.Authentication
{
    public class AdminSettings
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
