using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.Interfaces;
using ChallengerDisney.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengerDisney.Core.Services
{
    public class CharacterServices : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

    public CharacterServices(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }


    public IEnumerable<Character> GetAll()
    {
        return _characterRepository.GetAll();
    }

    public Task<Character> GetById(int id)
    {
        return _characterRepository.GetById(id);
    }

    public Task Add(Character character)
    {
        _characterRepository.Add(character);
        return _characterRepository.SaveChangesAsync();

    }

    public async Task<bool> Update(Character character)
    {
        _characterRepository.Update(character);
        await _characterRepository.SaveChangesAsync();
        return true;
    }


    public async Task<bool> Delete(int id)
    {
        await _characterRepository.Delete(id);
        return true;
    }

    public async Task<IEnumerable<Character>> GetListCaracter(CharacterFilter characterFilter)
    {
        return await _characterRepository.GetListCaracter(characterFilter);

    }

    }
}
