using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoPuzzle
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short? Difficulty { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<AsinoPuzzleVersion> Versions { get; set; }
        [JsonIgnore]
        public List<AsinoUserPuzzle> AsinoUserPuzzles { get; set; }
        [JsonIgnore]
        public List<AsinoDailyPuzzle> AsinoDailyPuzzles { get; set; }

        public Guid? CurrentVersionId { get; set; }
        public AsinoPuzzleVersion CurrentVersion { get; set; }

        [NotMapped]
        public bool? Bookmarked { get; set; }
        [NotMapped]
        public bool? Completed { get; set; }
        [NotMapped]
        public bool? Starred { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public string Date { get; set; }
    }
}
