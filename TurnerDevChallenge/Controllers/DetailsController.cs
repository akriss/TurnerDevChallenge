using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TurnerDevChallenge.Models;
using TurnerDevChallenge.Utils;

namespace TurnerDevChallenge.Controllers
{
    public class DetailsController : ApiController
    {
        private TurnerDevChallengeContext _context = new TurnerDevChallengeContext();

        // GET: api/Details
        public TitlesDetailDTO GetDetails(int titleId)
        {
            var details = from t in _context.Titles
                .Include(t => t.Award)
                .Include(t => t.TitleGenre)
                .Include(t => t.OtherName)
                .Include(t => t.TitleParticipant)
                .Include(t => t.StoryLine)
                          where t.TitleId == titleId
                          select new TitlesDetailDTO()
                          {
                              TitleId = t.TitleId,
                              TitleName = t.TitleName,
                              ReleaseYear = t.ReleaseYear,
                              ProcessedDateTimeUTC = t.ProcessedDateTimeUTC,
                              TitleNameSortable = t.TitleNameSortable,
                              TitleTypeId = t.TitleTypeId,
                              StoryLine = t.StoryLine,
                              TitleGenre = t.TitleGenre,
                              OtherName = t.OtherName,
                              TitleParticipant = t.TitleParticipant,
                              Award = t.Award,
                          };

            if (details == null)
            {
                return null;
            }


            var result = details.First();

            StringJoiner genres = new StringJoiner(", ");
            foreach (var genre in result.TitleGenre)
            {
                genres.Join(genre.Genre.Name);
            }
            result.GenreNames = genres.JoinedString;

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}