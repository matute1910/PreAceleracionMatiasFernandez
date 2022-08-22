using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengerDisney.Core.Interfaces
{
    public interface ICharacterRepository : IRepository<Character>
    {
        Task<IEnumerable<Character>> GetListCaracter(CharacterFilter characterFilter);
       
    }
}
