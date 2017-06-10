namespace TurnerDevChallenge.Models
{
    public class TitleParticipant
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int ParticipantId { get; set; }
        public bool IsKey { get; set; }
        public string RoleType { get; set; }
        public bool IsOnScreen { get; set; }

        public virtual Participant Participant { get; set; }
    }
}
