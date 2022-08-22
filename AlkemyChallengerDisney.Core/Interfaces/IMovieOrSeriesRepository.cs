using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengerDisney.Core.Interfaces
{
    public interface IMovieOrSeriesRepository : IRepository<MovieOrSeries>
    {
        IQueryable<MovieOrSeries> GetListMovie(MovieOrSerieFilter movieOrSeriesFilter);
    }
}
