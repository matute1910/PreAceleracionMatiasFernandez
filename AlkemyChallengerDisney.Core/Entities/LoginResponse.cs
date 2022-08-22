using System;

namespace ChallengerDisney.Core.Entities
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
