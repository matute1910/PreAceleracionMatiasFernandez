using System.ComponentModel.DataAnnotations;

namespace ChallengerDisney.Core.Entities
{
    public class RegisterUser
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
