using Microsoft.AspNetCore.Identity;

namespace ChallengerDisney.Core.Entities
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
