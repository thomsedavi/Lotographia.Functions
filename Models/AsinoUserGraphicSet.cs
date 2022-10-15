using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoUserGraphicSet
    {
        public string Role { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public Guid GraphicSetId { get; set; }
        public AsinoGraphicSet GraphicSet { get; set; }

        [NotMapped]
        public string GraphicSetTitle { get; set; }
    }
}
