using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoPuzzleCollectionVersion
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Design { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid CollectionId { get; set; }
        [JsonIgnore]
        public AsinoPuzzleCollection Collection { get; set; }

        [NotMapped]
        public List<AsinoPuzzle> Puzzles { get; set; }
        [NotMapped]
        public List<Setting> Settings { get; set; }
    }
}
