using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoDailyPuzzle
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public Guid PuzzleId { get; set; }
        [JsonIgnore]
        public AsinoPuzzle Puzzle { get; set; }

        [NotMapped]
        public string Title { get; set; }
    }
}
