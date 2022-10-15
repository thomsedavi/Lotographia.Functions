using System;
using System.Text.Json.Serialization;

namespace Lotographia.Models
{
    public class PaperFolliesParticipant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public PaperFolliesParticipantFlags Flags { get; set; }
        public string Content { get; set; }
        public int ContentIndex { get; set; }
        public int ContentVersion { get; set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }

        public long GameId { get; set; }
        public PaperFolliesGame Game { get; set; }

        public long? PrecedingPlayerId { get; set; }
        public PaperFolliesParticipant PrecedingPlayer { get; set; }
        public long? FollowingPlayerId { get; set; }
        public PaperFolliesParticipant FollowingPlayer { get; set; }
    }

    [Flags]
    public enum PaperFolliesParticipantFlags
    {
        None = 0,
        IsAdmin = 1 << 0,
        IsPlayer = 1 << 1,
        IsAdded = 1 << 2,
        IsEnded = 1 << 3
    }
}
