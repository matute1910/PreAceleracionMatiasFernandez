using ChallengerDisney.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChallengerDisney.Infraestructure.DataDB
{
    public partial class DisneyContext : DbContext
    {
        public DisneyContext()
        {
        }

        public DisneyContext(DbContextOptions<DisneyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<MovieOrSeries> MovieOrSeries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
