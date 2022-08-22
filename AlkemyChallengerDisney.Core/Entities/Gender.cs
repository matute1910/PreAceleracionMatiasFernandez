using System.Collections.Generic;

namespace ChallengerDisney.Core.Entities
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public IEnumerable<MovieOrSeries> MoviesOrAssociatedSeries { get; set; }
    }
}
