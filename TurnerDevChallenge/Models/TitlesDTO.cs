using System;
using System.Collections.Generic;

namespace TurnerDevChallenge.Models
{
    public class TitlesDTO
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUTC { get; set; }

        public string Url { get; set; }
    }

    public class TitlesDetailDTO
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUTC { get; set; }

        public ICollection<StoryLine> StoryLine { get; set; }
        public ICollection<Award> Award { get; set; }
        public ICollection<OtherName> OtherName { get; set; }
        public ICollection<TitleParticipant> TitleParticipant { get; set; }
        public ICollection<TitleGenre> TitleGenre { get; set; }
    }
}