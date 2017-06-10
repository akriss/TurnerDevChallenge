using TurnerDevChallenge.Utils;

namespace TurnerDevChallenge.Models
{
    public class OtherName
    {
        public int TitleId { get; set; }
        public string TitleNameLanguage { get; set; }
        public string TitleNameType { get; set; }
        public string TitleNameSortable { get; set; }
        public string TitleName { get; set; }
        public int Id { get; set; }
        
        public string PrintLanguageString()
        {
            return TitleCaseWriter.ToTitleCase(TitleNameLanguage);
        }
    }
}
