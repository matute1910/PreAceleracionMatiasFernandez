using ChallengerDisney.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChallengerDisney.Infraestructure.DataDB
{
    public class UserContext : IdentityDbContext<User>
    {
        private const string schema = "users";

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(schema);
        }
    }
}
