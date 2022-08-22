using System.ComponentModel.DataAnnotations;

namespace ChallengerDisney.Core.Entities
{
    public class LoginUser
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
