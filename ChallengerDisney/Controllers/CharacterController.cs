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
    
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;


        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCharacter()
        {
            
            var character = _characterService.GetAll();
            var charactersDto = _mapper.Map<IEnumerable<CharacterDto>>(character);

            var characterList = from characters in charactersDto
                                select new
                                {
                                    characters.Name,
                                    characters.Image
                                };

            return Ok(characterList);
        }

        [HttpGet("/characters")]
        public IActionResult GetListCaracter([FromQuery] CharacterFilter characterFilter)
        {
            var character = _characterService.GetAll();

            if (!string.IsNullOrWhiteSpace(characterFilter.Name)) 
                character = character.Where(x => x.Name == characterFilter.Name);

            if (characterFilter.Age != null)
                character = character.Where(x => x.Age == characterFilter.Age);

            if(characterFilter.IdMovie != null)
                character = character.Where(x => x.MoviesOrAssociatedSeries.Any(z => z.Id == characterFilter.IdMovie));

            var characterList = _mapper.Map<IEnumerable<CharacterDto>>(character);
            
            return Ok(characterList);

        }

        [HttpPost]
        public async Task<IActionResult> Add(CharacterDto characterDto)
        {
            var post = _mapper.Map<Character>(characterDto);
            await _characterService.Add(post);

            characterDto = _mapper.Map<CharacterDto>(post);
            
            return Ok(characterDto);

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            character.Id = id;

            var result = await _characterService.Update(character);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _characterService.Delete(id);
            
            return Ok(result);
        }

    }
}
