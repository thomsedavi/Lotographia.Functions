using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoUserPuzzleCollection
    {
        public string Role { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public Guid PuzzleCollectionId { get; set; }
        public AsinoPuzzleCollection PuzzleCollection { get; set; }

        [NotMapped]
        public string PuzzleCollectionTitle { get; set; }
    }
}
