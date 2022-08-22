using AutoMapper;
using ChallengerDisney.Core.DTOs;
using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.Interfaces;
using ChallengerDisney.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengerDisney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieOrSeriesController : Controller
    {
        private readonly IMovieOrSeriesServices _movieOrSeriesService;
        private readonly IMapper _mapper;


        public MovieOrSeriesController(IMovieOrSeriesServices movieOrSeriesService, IMapper mapper)
        {
            _movieOrSeriesService = movieOrSeriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovieOrSeries()
        {

            var movieOrSeries = _movieOrSeriesService.GetAll();
            var movieOrSeriesDto = _mapper.Map<IEnumerable<MovieOrSeriesDto>>(movieOrSeries);

            var movieOrSeriesList = from movieOrSerie in movieOrSeriesDto
                                select new
                                {
                                    movieOrSerie.Image,
                                    movieOrSerie.Tittle,
                                    movieOrSerie.CreationDate
                                
                                };

            return Ok(movieOrSeriesList);
        }


        [HttpPost]
        public async Task<IActionResult> Add(MovieOrSeriesDto movieOrSeriesDto)
        {
            var post = _mapper.Map<MovieOrSeries>(movieOrSeriesDto);
            await _movieOrSeriesService.Add(post);

            movieOrSeriesDto = _mapper.Map<MovieOrSeriesDto>(post);

            return Ok(movieOrSeriesDto);

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, MovieOrSeriesDto movieOrSeriesDto)
        {
            var character = _mapper.Map<MovieOrSeries>(movieOrSeriesDto);
            character.Id = id;

            var result = await _movieOrSeriesService.Update(character);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieOrSeriesService.Delete(id);

            return Ok(result);
        }

    }
}
