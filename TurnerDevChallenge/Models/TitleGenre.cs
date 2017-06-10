namespace TurnerDevChallenge.Models
{
    public class TitleGenre
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
