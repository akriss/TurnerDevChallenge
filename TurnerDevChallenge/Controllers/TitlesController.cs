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
    public class TitlesController : ApiController
    {
        private TurnerDevChallengeContext _context = new TurnerDevChallengeContext();

        // GET: api/Titles
        public IList<TitlesDTO> GetTitles(string searchString)
        {
            IQueryable<TitlesDTO> titles;
            if(String.IsNullOrEmpty(searchString))
            {
                return null;
            }
            else
            {
                titles = from t in _context.Titles
                    where t.TitleName.Contains(searchString ?? "")
                    orderby t.TitleNameSortable
                    select new TitlesDTO()
                    {
                        TitleId = t.TitleId,
                        TitleName = t.TitleName
                    };
            }

            var result = titles.ToList();
            foreach(var title in result)
            {
                title.Url = UrlCleaner.CleanUrl(Url.Link("", new { controller = "Details", titleId = title.TitleId }));
            }
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