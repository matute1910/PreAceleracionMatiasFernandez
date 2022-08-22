using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.Interfaces;
using ChallengerDisney.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengerDisney.Core.Services
{
    public class MovieOrSeriesServices : IMovieOrSeriesServices
    {
        private readonly IMovieOrSeriesRepository _movieOrSeriesRepository;

        public MovieOrSeriesServices(IMovieOrSeriesRepository movieOrSeriesRepository)
        {
            _movieOrSeriesRepository = movieOrSeriesRepository;
        }


        public IEnumerable<MovieOrSeries> GetAll()
        {
            return _movieOrSeriesRepository.GetAll();
        }

        public Task<MovieOrSeries> GetById(int id)
        {
            return _movieOrSeriesRepository.GetById(id);
        }

        public Task Add(MovieOrSeries movieOrSeries)
        {
            _movieOrSeriesRepository.Add(movieOrSeries);
            return _movieOrSeriesRepository.SaveChangesAsync();

        }

        public async Task<bool> Update(MovieOrSeries movieOrSeries)
        {
            _movieOrSeriesRepository.Update(movieOrSeries);
            await _movieOrSeriesRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _movieOrSeriesRepository.Delete(id);
            return true;
        }

        public IQueryable<MovieOrSeries> GetListMovie(MovieOrSerieFilter movieOrSeriesFilter)
        {
           return _movieOrSeriesRepository.GetListMovie(movieOrSeriesFilter);
           
        }
    }
}
