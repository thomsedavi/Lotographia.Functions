using System;
using System.Collections.Generic;

namespace Lotographia.Functions.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Provider { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<AsinoUserPuzzle> AsinoUserPuzzles { get; set; }
        public List<AsinoUserPuzzleCollection> AsinoUserPuzzleCollections { get; set; }
        public List<AsinoUserGraphicSet> AsinoUserGraphicSets { get; set; }
    }
}
