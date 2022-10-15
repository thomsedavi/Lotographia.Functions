using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lotographia.Models
{
    public class LexicologerGame
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int CharacterLimit { get; set; }
        public List<LexicologerWord> Words { get; set; }
    }

    public class LexicologerWord
    {
        public string PrimaryWord { get; set; }
        public List<string> SecondaryWords { get; set; }
    }
}
