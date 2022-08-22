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
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(DisneyContext context) : base(context) { }



        public async Task<IEnumerable<Character>> GetListCaracter(CharacterFilter characterFilter)
        {
            return await _entities.Where(x => x.Name == characterFilter.Name && x.Age == characterFilter.Age).ToListAsync();
        }
        
    }
}
