using TurnerDevChallenge.Utils;

namespace TurnerDevChallenge.Models
{
    public class StoryLine
    {
        public int TitleId { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public string PrintLanguageString()
        {
            return TitleCaseWriter.ToTitleCase(Language);
        }
    }
}
