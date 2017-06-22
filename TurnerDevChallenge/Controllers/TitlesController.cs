using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using TurnerDevChallenge.Models;

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
                title.Url = Url.Link("Default", new { controller = "Home", action = "Details", titleId = title.TitleId });
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