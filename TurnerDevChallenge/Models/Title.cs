using System;
using System.Collections.Generic;

namespace TurnerDevChallenge.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUTC { get; set; }

        public virtual ICollection<StoryLine> StoryLine { get; set; }
        public virtual ICollection<Award> Award { get; set; }
        public virtual ICollection<OtherName> OtherName { get; set; }
        public virtual ICollection<TitleParticipant> TitleParticipant { get; set; }
        public virtual ICollection<TitleGenre> TitleGenre { get; set; }
    }
}
