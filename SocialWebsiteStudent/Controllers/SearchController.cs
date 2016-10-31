using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialWebsiteStudent.Models;

namespace SocialWebsiteStudent.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();


        //If(pierwszy znak w wyszukiwaniu to @ wyszukaj w _db.User jeśli zaczyna się od # to w _db.Tags
        // wtedy redirectToAction(select _db.User) else redirectToAction(select _db.Tags etc)

        // GET: Search
        public ActionResult Index(string value)
        {
            var found = (from f in _db.Users where f.UserName == value select f);

            return View();
        }

        
    }
}
