using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengerDisney.Core.Interfaces
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetAll();
        Task<Character> GetById(int id);
        Task Add(Character character);
        Task<bool> Update(Character character);
        Task<bool> Delete(int id);

        Task<IEnumerable<Character>> GetListCaracter(CharacterFilter characterFilter);
        

    }
}
