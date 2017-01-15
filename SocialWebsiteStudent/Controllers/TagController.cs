using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Repository.Interface;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class TagController : Controller
    {

        private readonly ITagRepository _repo;

        public TagController(ITagRepository repo)
        {
            _repo = repo;
        }
       
        
        // Show all post from searching tag
        public ActionResult ShowPostFromTag(string tagName)
        {
            var postFromTags = _repo.GetPostsFromTags(tagName);

            if (!postFromTags.Any())
            {
                return RedirectToAction("ErroResult", "Search");
            }

            return View(postFromTags.ToList());
        }

    }
}