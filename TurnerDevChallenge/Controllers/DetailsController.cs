using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurnerDevChallenge.Models;

namespace TurnerDevChallenge.Controllers
{
    public class DetailsController : Controller
    {
        private TurnerDevChallengeContext _context = new TurnerDevChallengeContext();

        // GET: Details
        public async Task<ActionResult> Index(int titleId)
        {
            var title = await _context.Titles
                .Include(t => t.Award)
                .Include(t => t.TitleGenre)
                .Include(t => t.OtherName)
                .Include(t => t.TitleParticipant)
                .Include(t => t.StoryLine).Select(t =>
                new TitlesDetailDTO()
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
                }).SingleOrDefaultAsync(t => t.TitleId == titleId);

            var model = new DetailsViewModel(title);

            return View(model);
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
