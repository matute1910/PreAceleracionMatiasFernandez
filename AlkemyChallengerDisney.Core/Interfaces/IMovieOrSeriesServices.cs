using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengerDisney.Core.Interfaces
{
    public interface IMovieOrSeriesServices
    {
        IEnumerable<MovieOrSeries> GetAll();
        Task<MovieOrSeries> GetById(int id);
        Task Add(MovieOrSeries movieOrSeries);
        Task<bool> Update(MovieOrSeries movieOrSeries);
        Task<bool> Delete(int id);

        IQueryable<MovieOrSeries> GetListMovie(MovieOrSerieFilter movieOrSeriesFilter);
    }
}
