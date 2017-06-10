using System.ComponentModel.DataAnnotations.Schema;

namespace TurnerDevChallenge.Models
{
    public class Award
    {
        public int TitleId { get; set; }
        public bool? AwardWon { get; set; }
        public int? AwardYear { get; set; }
        // Column mapping needed, since table is also called Award
        [Column("Award", TypeName = "varchar")]
        public string AwardName { get; set; }
        public string AwardCompany { get; set; }
        public int Id { get; set; }
    }
}
