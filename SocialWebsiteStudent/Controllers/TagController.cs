using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // Show all post from searching tag
        public ActionResult ShowPostFromTag(string tagName)
        {
            var postFromTags = (from post in _db.Posts
                where
                post.Tags.Any(tag => tag.TagName == tagName)
                orderby post.PostDateTime
                select post);

            if (!postFromTags.Any())
            {
                return RedirectToAction("ErroResult", "Search");
            }


            return View(postFromTags.ToList());
        }


        // Autocomplete method 
        public ActionResult GetTag(string term)
        {
            var tags = new List<string>()
            {
                (from t in _db.Tags select t).ToString()
            };

            IEnumerable<string> data;

            if (term != null)
            {
                data = tags.Where(x => x.StartsWith(term));
            }
            else
                data = tags;

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}