using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoGraphic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Design { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<AsinoGraphicVersion> Versions { get; set; }

        public Guid SetId { get; set; }
        [JsonIgnore]
        public AsinoGraphicSet Set { get; set; }

        public Guid? CurrentVersionId { get; set; }
        public AsinoGraphicVersion CurrentVersion { get; set; }
    }
}
