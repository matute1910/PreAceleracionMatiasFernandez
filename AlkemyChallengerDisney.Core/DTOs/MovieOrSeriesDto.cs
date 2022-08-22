using ChallengerDisney.Core.Entities;
using System;
using System.Collections.Generic;

namespace ChallengerDisney.Core.DTOs
{
    public class MovieOrSeriesDto
     {
        public string Tittle { get; set; }
        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }
        public string Image { get; set; }
        public IEnumerable<Character> ListOfCharacters { get; set; }
    }
}
