using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoPuzzleCollection
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<AsinoPuzzleCollectionVersion> Versions { get; set; }
        [JsonIgnore]
        public List<AsinoUserPuzzleCollection> AsinoUserPuzzleCollections { get; set; }

        public Guid? CurrentVersionId { get; set; }
        public AsinoPuzzleCollectionVersion CurrentVersion { get; set; }

        [NotMapped]
        public List<AsinoPuzzle> Puzzles { get; set; }
        [NotMapped]
        public List<Setting> Settings { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
