using System.Linq;
using System.Web.Mvc;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // Action for searching result,
        // User can found tag, user, any word from post and comment 
        public ActionResult FoundResult(string value)
        {
            if (value.Contains("#"))
            {
                return RedirectToAction("ShowPostFromTag", "Tag", new {tagName = value});
            }
            if (value.Contains("@"))
            {
                var userFromValue = value.TrimStart(new char[] {'@'});

                return RedirectToAction("ProfileSite", "User", new {name = userFromValue});
            }
            if (!value.Contains("#") || !value.Contains("@"))
            {
                return RedirectToAction("ContentFoundResult", new {foundContent = value});
            }

            return RedirectToAction("ErroResult");
        }


        // Content found in database, nie działa - poprawić ten contain, zapytanie zwraca null
        // Jak dobrać select aby pobrało tylko to co zawiera string. 
        public ActionResult ContentFoundResult(string foundContent)
        {
            var found = (from f in _db.Posts
                join hehehe in _db.Comments on f.ID equals hehehe.PostId
                where f.PostContent.Contains(foundContent)
                select f);
            return View(found.ToList());
        }

        // Shows error when user isn't found any record
        public ActionResult ErroResult()
        {
            return View();
        }

    }
}