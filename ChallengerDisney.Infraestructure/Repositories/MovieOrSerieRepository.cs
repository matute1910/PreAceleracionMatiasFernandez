using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.Interfaces;
using ChallengerDisney.Core.QueryFilters;
using ChallengerDisney.Infraestructure.DataDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengerDisney.Infraestructure.Repositories
{
    public class MovieOrSeriesRepository : BaseRepository<MovieOrSeries>, IMovieOrSeriesRepository
    {
        public MovieOrSeriesRepository(DisneyContext context) : base(context) { }



        public IQueryable<MovieOrSeries> GetListMovie(MovieOrSerieFilter movieOrSeriesFilter)
        {
             return _entities.Where(x => x.Tittle == movieOrSeriesFilter.Tittle && x.CreationDate == movieOrSeriesFilter.CreationDate);
        }

    }
}
