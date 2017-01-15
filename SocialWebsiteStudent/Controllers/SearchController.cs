using System.Linq;
using System.Web.Mvc;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Repository.Interface;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository _repo;

        public SearchController(ISearchRepository repo)
        {
            _repo = repo;
        }
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
            var found = _repo.GetFoundContent(foundContent);
            return View(found);
        }

        // Shows error when user isn't found any record
        public ActionResult ErroResult()
        {
            return View();
        }
    }
}