using ChallengerDisney.Core.Entities;
using System.Collections.Generic;

namespace ChallengerDisney.Core.DTOs
{
    public class GenderDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieOrSeries> MoviesOrAssociatedSeries { get; set; }
    }
}
