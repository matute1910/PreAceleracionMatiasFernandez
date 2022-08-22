using System;

namespace ChallengerDisney.Core.QueryFilters
{
    public class MovieOrSerieFilter
    {
        public string Tittle { get; set; }

        public int? IdGenero { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
