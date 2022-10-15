using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoUserPuzzle
    {
        public bool? Starred { get; set; }
        public bool? Bookmarked { get; set; }
        public bool? Completed { get; set; }
        public string Role { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public Guid PuzzleId { get; set; }
        [JsonIgnore]
        public AsinoPuzzle Puzzle { get; set; }

        [NotMapped]
        public string PuzzleTitle { get; set; }
    }
}
