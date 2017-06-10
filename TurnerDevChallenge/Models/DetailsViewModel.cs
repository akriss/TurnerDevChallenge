using System.Web.Http.Results;
using System.Web.Mvc;
using TurnerDevChallenge.Utils;

namespace TurnerDevChallenge.Models
{
    public class DetailsViewModel
    {
        public DetailsViewModel(TitlesDetailDTO title)
        {
            Title = title;
        }
        public TitlesDetailDTO Title { get; set; }

        public string PrintGenreNames()
        {
            StringJoiner names = new StringJoiner(", ");

            foreach (var genre in Title.TitleGenre)
            {
                names.Join(genre.Genre.Name);
            }

            return names.JoinedString;
        }
    }
}
