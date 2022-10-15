using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Lotographia.Models
{
    public class PaperFolliesGame
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PaperFolliesGameFlags Flags { get; set; }
        public int CharacterLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EndedDate { get; set; }

        [JsonIgnore]
        public List<PaperFolliesParticipant> Participants { get; set; }
        
        [NotMapped]
        public IEnumerable<PaperFolliesParticipant> Players => Participants
            .Where(p => p.Flags.HasFlag(PaperFolliesParticipantFlags.IsAdded));
    }

    [Flags]
    public enum PaperFolliesGameFlags
    {
        None = 0,
        CanSeePrecedingContent = 1 << 0,
        CanSeeFollowingContent = 1 << 1,
        AddPlayersManually = 1 << 2,
        ParticipantsHaveBiographies = 1 << 3,
        RandomlyOrderPlayers = 1 << 4,
        IsStarted = 1 << 5,
        IsEnding = 1 << 6,
        IsEnded = 1 << 7,
        IsShared = 1 << 8
    }
}
