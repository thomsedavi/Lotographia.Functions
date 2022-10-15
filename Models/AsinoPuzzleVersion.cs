using System;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoPuzzleVersion
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Design { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid PuzzleId { get; set; }
        [JsonIgnore]
        public AsinoPuzzle Puzzle { get; set; }
    }
}
