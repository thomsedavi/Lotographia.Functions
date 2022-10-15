using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lotographia.Functions.Models
{
    public class AsinoGraphicSet
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<AsinoGraphic> Graphics { get; set; }
        [JsonIgnore]
        public List<AsinoUserGraphicSet> AsinoUserGraphicSets { get; set; }
    }
}
