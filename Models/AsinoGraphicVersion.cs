using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoGraphicVersion
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Design { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid GraphicId { get; set; }
        [JsonIgnore]
        public AsinoGraphic Graphic { get; set; }

        [NotMapped]
        public string Type { get; set; }
    }
}
