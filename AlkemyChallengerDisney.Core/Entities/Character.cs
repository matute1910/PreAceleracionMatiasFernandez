using System.Collections.Generic;

namespace ChallengerDisney.Core.Entities
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string History { get; set; }
        public string Image { get; set; }

        public IEnumerable<MovieOrSeries> MoviesOrAssociatedSeries { get; set; }
    }
}
